package tul.securityviewer.Communication;

import android.content.Context;
import android.os.Handler;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.InetAddress;
import java.net.Socket;
import java.util.concurrent.TimeUnit;

public class Client {
    Handler UIHandler;
    Thread thread;
    InitializeConnection initializeConnection;

    private String IP;
    private int PORT;

    private Notification notification;
    private Socket clientSocket;
    private Context activity;

    private BufferedReader streamIn;  // Read string
    private OutputStreamWriter streamOut;  // Send string

    public Client(String ipAddress, int port, Context activity) {
        notification = new Notification(activity);

        // Setup destination
        this.IP = ipAddress;
        this.PORT = port;

        // ???
        UIHandler = new Handler();
        this.activity = activity;

        // Startup TCP/IP communication thread
        initializeConnection = new InitializeConnection();
        this.thread = new Thread(initializeConnection);
        this.thread.start();

        // Initialize role
        try {
            TimeUnit.SECONDS.sleep(1);
        }
        catch (Exception exception){
            notification.Toast("Sleep exception: " + exception.getMessage());
        }
        Send("SecurityViewer");
    }

    // Send message to server
    public void Send(String message) {
        try{
            streamOut.write(message);
            streamOut.flush();
        }
        catch (Exception exception){
            notification.Toast("Send exception: " + exception.getMessage());
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
            notification.Toast("Message: " + message);
        }
    }

    // close connection
    public void close() {
        try {
            initializeConnection.terminate();
            thread.join();
            //if (clientSocket != null)    clientSocket.close();
            //if (streamIn != null)  streamIn.close();
            //if (streamOut != null) streamOut.close();
        }
        catch (Exception exception){
            notification.Toast("Closing exception: " + exception.getMessage());
        }
    }

    // TCP/IP client
    private class InitializeConnection implements Runnable {
        private volatile boolean running = true;

        @Override
        public void run() {
            while(running){
                try {
                    // Setup destination
                    InetAddress serverAddress = InetAddress.getByName(IP);
                    clientSocket = new Socket(serverAddress, PORT);

                    ThreadCommunication threadCommunication = new ThreadCommunication();
                    new Thread(threadCommunication).start();
                    return;

                } catch (Exception exception){
                    notification.Toast("InitializeConnection run exception: " + exception.getMessage());
                }
            }
        }

        public void terminate(){
            running = false;
        }
    }

    // TCP/IP communication
    private class ThreadCommunication implements Runnable {
        private ThreadCommunication(){
            try {
                streamIn = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));  // Message received
                streamOut = new OutputStreamWriter(clientSocket.getOutputStream());  // Message sending
            } catch (Exception exception) {
                notification.Toast("ThreadCommunication create exception: " + exception.getMessage());
            }
        }

        // Started after main methods
        @Override
        public void run() {
            while (!Thread.currentThread().isInterrupted()){
                try{
                    String message = streamIn.readLine();
                    if (message != null) {
                        UIHandler.post(new MessageReceived(message));
                    }
                    else{
                        thread = new Thread(new Thread());
                        thread.start();
                        return;
                    }
                } catch (Exception exception) {
                    notification.Toast("ThreadCommunication run exception: " + exception.getMessage());
                }
            }
        }
    }
}
