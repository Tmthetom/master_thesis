package tul.securityviewer.Communication;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.InetAddress;
import java.net.Socket;
import java.net.UnknownHostException;

public class ClientTest01  {

    private static final int SERVERPORT = 4444;
    private Socket socket;
    private String SendString;
    public boolean sendDone = true;

    public ClientTest01() {

        SendString = "Hello, this is an android client...";

        InetAddress serverAddr;
        try {
            serverAddr = InetAddress.getByName("81.200.57.24");

            try {
                socket = new Socket(serverAddr, 6666);
            } catch (IOException e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        } catch (UnknownHostException e) {
            e.printStackTrace();
        }
    }

    public void TCPClientClose() {
        try {
            socket.close();
        } catch (IOException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
    }

    public void sendString(String s) {
        try {
            PrintWriter out = new PrintWriter(new BufferedWriter(
                    new OutputStreamWriter(socket.getOutputStream())), true);

            out.println(s);
        } catch (Exception e) {
            ;
        }
    }

    public String readString() {
        BufferedReader bufferedReader;
        int anzahlZeichen = 0;
        String nachricht = "";
        try {
            bufferedReader = new BufferedReader(
                    new InputStreamReader(
                            socket.getInputStream()));

            char[] buffer = new char[200];
            anzahlZeichen = bufferedReader.read(buffer, 0, 200); // blockiert bis Nachricht empfangen
            nachricht = new String(buffer, 0, anzahlZeichen);
        } catch (IOException e) {
            // TODO Auto-generated catch block
        }

        return nachricht;
    }

}