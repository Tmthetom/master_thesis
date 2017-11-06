package tul.securityviewer.Communication;

import android.content.Context;
import android.os.Handler;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.InetAddress;
import java.net.Socket;

public class ClientTest {
    Handler UIHandler;
    Thread thread;

    private String IP;
    private int PORT;
    private Notification notification;

    public ClientTest(String ipAddress, int port, Context activity) {
        notification = new Notification(activity);

        // Setup destination
        this.IP = ipAddress;
        this.PORT = port;

        // ???
        UIHandler = new Handler();

        // Startup TCP/IP communication thread
        this.thread = new Thread(new InitializeConnection());
        this.thread.start();
    }

    // Send message to server
    public void Send(String message) {
        /*
        ClientTest02 messageSender = new ClientTest02();
        messageSender.execute(message);*/
    }


    // TCP/IP client
    private class InitializeConnection implements Runnable {
        @Override
        public void run() {
            try {
                // Setup destination
                InetAddress serverAddress = InetAddress.getByName(IP);
                Socket socket = new Socket(serverAddress, PORT);

                ThreadCommunication threadCommunication = new ThreadCommunication(socket);
                new Thread(threadCommunication).start();
                return;

            } catch (Exception exception){
                notification.Toast("InitializeConnection run exception: " + exception.getMessage());
            }
        }
    }

    // TCP/IP communication
    private class ThreadCommunication implements Runnable {

        private Socket clientSocket;
        private BufferedReader bufferedReader;

        private ThreadCommunication(Socket clientSocket){
            this.clientSocket = clientSocket;
            try {
                // Message received
                //this.buffer
                this.bufferedReader = new BufferedReader(new InputStreamReader(this.clientSocket.getInputStream()));
            } catch (Exception exception) {
                notification.Toast("ThreadCommunication create exception: " + exception.getMessage());
            }
        }

        // Started after main methods
        @Override
        public void run() {
            while (!Thread.currentThread().isInterrupted()){
                try{
                    String read = bufferedReader.readLine();
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
}
