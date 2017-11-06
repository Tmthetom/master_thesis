package tul.securityviewer.Communication;

import android.os.AsyncTask;

import java.io.DataOutputStream;
import java.io.IOException;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;

public class ClientTest02 extends AsyncTask<String,Void,Void>{
    Socket socket;
    PrintWriter printWriter;

    @Override
    protected Void doInBackground(String... voids) {
        String message = voids[0];

        try{
            socket = new Socket("81.200.57.24", 6666);
            printWriter = new PrintWriter(socket.getOutputStream());
            printWriter.write(message);
            printWriter.flush();
            printWriter.close();
            socket.close();

        } catch (UnknownHostException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

        return null;
    }
}
