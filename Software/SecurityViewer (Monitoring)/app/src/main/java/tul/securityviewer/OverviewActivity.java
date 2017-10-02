package tul.securityviewer;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.InetAddress;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;

public class OverviewActivity extends AppCompatActivity {

    private ServerSocket serverSocket;
    Thread thread = null;

    public static final int PORT = 6666;
    public static final String IP = "81.200.57.24";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.overview);

        // Startup TCP/IP communication thread
        this.thread = new Thread(new ThreadClient());
        this.thread.Start();

        // Create testing items
        CustomListItem item1 = new CustomListItem(CustomListItem.Type.SENSOR, 0, 3, "Door sensor", true, false);
        CustomListItem item2 = new CustomListItem(CustomListItem.Type.SENSOR, 1, 5, "PIR sensor", false, true);
        CustomListItem item3 = new CustomListItem(CustomListItem.Type.SWITCH, 2, 8, "Light switch", true, false);

        // Add items into list
        ArrayList<CustomListItem> items = new ArrayList<CustomListItem>();
        items.add(item1);
        items.add(item2);
        items.add(item3);

        // Set listView adapter
        ListView listView = (ListView) findViewById(R.id.listView);
        ListAdapter listAdapter = new CustomAdapter(this, items);
        listView.setAdapter(listAdapter);
    }

    // TCP/IP client
    class ThreadClient implements Runnable {
        @Override
        public void run() {
            Socket socket = null;

            try {
                InetAddress serverAddress = InetAddress.getByName(IP);
                socket = new Socket(serverAddress, PORT);

                ThreadCommunication communicationThread = new ThreadCommunication(socket);
                new Thread(communicationThread).Start();
                return;
            } catch (Exception exception){
                Notification("ThreadClient exception: " + exception.getMessage());
            }
        }
    }

    // TCP/IP communication
    class ThreadCommunication implements Runnable {
        private Socket clientSocket;
        private BufferedReader input;

        public ThreadCommunication(Socket clientSocket){
            this.clientSocket = clientSocket;

            try {
                this.input = new BufferedReader(new InputStreamReader(this.clientSocket.getInputStream()));
            } catch (Exception exception) {
                Notification("ThreadCommunication create exception: " + exception.getMessage());
            }
        }

        @Override
        public void run() {
            while (!Thread.currentThread().isInterrupted()){
                try{
                    String read = input.readLine();
                    if (read != null) {
                        UI
                    }
                } catch (Exception exception) {
                    Notification("ThreadCommunication run exception: " + exception.getMessage());
                }
            }
        }
    }

    // Create option settings_menu in right up corner
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu, menu);
        return true;
    }

    // Handle menu items click
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()){
            case R.id.refresh:
                Notification("Refresh is not implemented yet");
                return true;
            case R.id.hide_notification:
                Notification("Hide notification is not implemented yet");
                return true;
            default:
                return true;
        }
    }

    // Notification
    public void Notification(String message){
        Toast.makeText(this, message, Toast.LENGTH_SHORT).show();
    }
}