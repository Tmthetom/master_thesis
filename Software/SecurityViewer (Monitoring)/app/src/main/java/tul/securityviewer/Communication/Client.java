package tul.securityviewer.Communication;

import android.os.Handler;

import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.InetAddress;
import java.net.Socket;
import java.util.concurrent.TimeUnit;

import tul.securityviewer.Activity.MainActivity;

public class Client {
    private Handler UIHandler;
    private Thread thread;
    private InitializeConnection initializeConnection;

    private String IP;
    private int PORT;

    private Notification notification;
    private Socket clientSocket;
    private MainActivity mainActivity;  // Main activity with items

    private InputStreamReader streamIn;  // Read string
    private OutputStreamWriter streamOut;  // send string

    public Client(String ipAddress, int port, MainActivity activity) {
        notification = new Notification(activity);

        // Setup destination
        this.IP = ipAddress;
        this.PORT = port;

        // To interact UI from thread (like Delegates from C#)
        UIHandler = new Handler();
        this.mainActivity = activity;

        // Startup TCP/IP communication thread
        initializeConnection = new InitializeConnection();
        this.thread = new Thread(initializeConnection);
        this.thread.start();

        /*
        HERE SHOULD BE CHECK, IF CONNECTION IS ESTABLISHED, INSTEAD OF JUST ONE SECOND DELAY
         */

        // Initialize role
        sleep(1);
        send("SecurityViewer");
    }

    // send message to server
    public void send(String message) {
        try{
            streamOut.write(message);
            streamOut.flush();
        }
        catch (Exception exception){
            notification.toast("send exception: " + exception.getMessage());
        }
    }

    // Called when message received
    private class MessageReceived implements Runnable {

        private String message;

        private MessageReceived(String message) {
            this.message = message;
        }

        // Started after main methods
        @Override
        public void run() {
            mainActivity.tryParseData(message);
        }
    }

    // Sleep for set time
    private void sleep(int seconds){
        try {
            TimeUnit.SECONDS.sleep(seconds);
        }
        catch (Exception exception){
            notification.toast("Sleep exception: " + exception.getMessage());
        }
    }

    /*
    THIS NEED TO BE FIXED, NOW IS PROBLEM WITH ORDER OF CLOSING
     */

    // Close connection
    public void close() {
        try {
            //initializeConnection.terminate();
            //thread.join();
            //if (clientSocket != null)    clientSocket.close();
            //if (streamIn != null)  streamIn.close();
            //if (streamOut != null) streamOut.close();
        }
        catch (Exception exception){
            notification.toast("Closing exception: " + exception.getMessage());
        }
    }

    // TCP/IP client
    private class InitializeConnection implements Runnable {
        private volatile boolean running = true;

        @Override
        public void run() {
            //while(running){
                try {
                    // Setup destination
                    InetAddress serverAddress = InetAddress.getByName(IP);
                    clientSocket = new Socket(serverAddress, PORT);

                    ThreadCommunication threadCommunication = new ThreadCommunication();
                    new Thread(threadCommunication).start();
                    return;

                } catch (Exception exception){
                    notification.toast("InitializeConnection run exception: " + exception.getMessage());
                }
            //}
        }

        public void terminate(){
            running = false;
        }
    }

    // TCP/IP communication
    private class ThreadCommunication implements Runnable {
        private ThreadCommunication(){
            try {
                //streamIn = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));  // Message received
                streamIn = new InputStreamReader(clientSocket.getInputStream());  // Message received
                streamOut = new OutputStreamWriter(clientSocket.getOutputStream());  // Message sending
            } catch (Exception exception) {
                notification.toast("ThreadCommunication create exception: " + exception.getMessage());
            }
        }

        // Started after main methods
        @Override
        public void run() {
            while (!Thread.currentThread().isInterrupted()){
                try{

                    /*
                     This part seems really problematic, when reading line or trying to read EOL,
                     code seems to been stuck in infinite loop, like infinite reading. Fixed with
                     own final character, but its not best solution.
                      */

                    // Read all
                    String message = "";
                    while(!message.endsWith("§")){  // Until this special character came....
                        message += (char)streamIn.read();
                    }
                    message = message.replace("§", "");

                    // send it to notification
                    UIHandler.post(new MessageReceived(message));

                } catch (Exception exception) {
                    notification.toast("ThreadCommunication run exception: " + exception.getMessage());
                }
            }
        }
    }
}
