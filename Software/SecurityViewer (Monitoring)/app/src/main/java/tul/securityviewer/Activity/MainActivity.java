package tul.securityviewer.Activity;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ListAdapter;
import android.widget.ListView;

import java.util.ArrayList;

import tul.securityviewer.Communication.Client;
import tul.securityviewer.Communication.DataParser;
import tul.securityviewer.Communication.Notification;
import tul.securityviewer.Communication.Operations;
import tul.securityviewer.CustomList.CustomAdapter;
import tul.securityviewer.CustomList.CustomListItem;
import tul.securityviewer.R;

public class MainActivity extends AppCompatActivity {

    Client client;
    Operations operations = new Operations();
    DataParser dataParser = new DataParser();
    Notification notification = new Notification(this);

    private String IP = "81.200.57.24";  // Address of SecurityServer
    private int PORT = 6666;  // Port of SecurityServer

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);

        // Startup TCP/IP communication thread
        client = new Client(IP, PORT, this);
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
                operations.getAllItems(client);
                return true;
            case R.id.send:
                client.send("Testing message");
                return true;
            case R.id.testing_data:
                createParsedTestingItems();
                return true;
            case R.id.hide_notification:
                notification.toast("Hide notification is not implemented yet");
                return true;
            default:
                return true;
        }
    }

    private void createParsedTestingItems(){

        // Create empty list
        ArrayList<CustomListItem> items = new ArrayList<>();

        // Add sensors
        dataParser.sensors(items,
                "(Id = 2,Pin = 6,Name = Testing sensor 1,State = 0,Type = 0)," +
                "(Id = 3,Pin = 8,Name = Testing sensor 2,State = 1,Type = 0)," +
                "(Id = 4,Pin = 9,Name = Testing sensor 3,State = 0,Type = 0)"
        );

        // Add switches
        dataParser.switches(items,
                "(Id = 1,Pin = 2,Name = Testing switch 1,State = 0)," +
                "(Id = 5,Pin = 3,Name = Testing switch 2,State = 1)," +
                "(Id = 7,Pin = 5,Name = Testing switch 3,State = 0)"
        );

        if (items.size() == 0) return;

        // Set listView adapter
        ListView listView = (ListView) findViewById(R.id.listView);
        ListAdapter listAdapter = new CustomAdapter(this, items);
        listView.setAdapter(listAdapter);
    }

    public void tryParseData(String data){
        notification.toast(data);

        ArrayList<CustomListItem> items = new ArrayList<>();

        // Try to parse sensors
        dataParser.sensors(items, data);

        // Try to parse switches, when no sensors founded
        if (items.size() == 0) dataParser.switches(items, data);

        // Set listView adapter
        ListView listView = (ListView) findViewById(R.id.listView);
        ListAdapter listAdapter = new CustomAdapter(this, items);
        listView.setAdapter(listAdapter);
    }
}