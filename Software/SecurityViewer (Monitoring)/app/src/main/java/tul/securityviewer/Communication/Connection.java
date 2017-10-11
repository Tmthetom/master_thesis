package tul.securityviewer.Communication;

import android.content.Context;
import android.os.Handler;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.InetAddress;
import java.net.Socket;

public class Connection {
    Handler UIHandler;
    Thread thread = null;

    private String IP;
    private int PORT;
    private Notification notification;
    private String buffer;

    public Connection(String ipAddress, int port, Context activity) {
        notification = new Notification(activity);

        // Setup TCP/IP
        this.IP = ipAddress;
        this.PORT = port;

        // Startup TCP/IP communication thread
        this.thread = new Thread(new ThreadClient());
        this.thread.start();
        UIHandler = new Handler();
    }

    // Send message to server
    public void Send(String message){
        ;
    }

    // Read messages from server
    public String Read(){
        while(){

        }
    }

    // Called when message received
    private class MessageReceived implements Runnable {
        private String message;
        private MessageReceived(String message) {
            this.message = message;
        }

        @Override
        public void run() {
            notification.Toast("Message: " + message);
        }
    }

    // TCP/IP client
    private class ThreadClient implements Runnable {
        @Override
        public void run() {
            Socket socket = null;

            try {
                InetAddress serverAddress = InetAddress.getByName(IP);
                socket = new Socket(serverAddress, PORT);

                ThreadCommunication threadCommunication = new ThreadCommunication(socket);
                new Thread(threadCommunication).start();
                return;
            } catch (Exception exception){
                notification.Toast("ThreadClient exception: " + exception.getMessage());
            }
        }
    }

    // TCP/IP communication
    private class ThreadCommunication implements Runnable {
        private Socket clientSocket;
        private BufferedReader input;

        private ThreadCommunication(Socket clientSocket){
            this.clientSocket = clientSocket;
            try {
                // Message received
                this.buffer
                this.input = new BufferedReader(new InputStreamReader(this.clientSocket.getInputStream()));
            } catch (Exception exception) {
                notification.Toast("ThreadCommunication create exception: " + exception.getMessage());
            }
        }

        @Override
        public void run() {
            while (!Thread.currentThread().isInterrupted()){
                try{
                    String read = input.readLine();
                    if (read != null) {
                        UIHandler.post(new MessageReceived(read));
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
