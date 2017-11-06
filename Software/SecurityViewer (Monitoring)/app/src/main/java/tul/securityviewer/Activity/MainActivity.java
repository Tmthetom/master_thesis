package tul.securityviewer.Activity;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ListAdapter;
import android.widget.ListView;

import java.net.Socket;
import java.util.ArrayList;

import tul.securityviewer.Communication.ClientTest01;
import tul.securityviewer.Communication.ClientTest;
import tul.securityviewer.Communication.ClientTest03;
import tul.securityviewer.Communication.DataParser;
import tul.securityviewer.Communication.Notification;
import tul.securityviewer.CustomList.CustomAdapter;
import tul.securityviewer.CustomList.CustomListItem;
import tul.securityviewer.R;

public class MainActivity extends AppCompatActivity {

    ClientTest03 clientTest;
    DataParser dataParser;
    Notification notification = new Notification(this);

    private String IP = "81.200.57.24";
    private int PORT = 6666;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);

        // Startup TCP/IP communication thread
        clientTest = new ClientTest03(IP, PORT, this);
        clientTest.Send("security");
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
                //notification.Toast("Refresh is not implemented yet");
                //createTestingItems();
                clientTest.Close();
                return true;
            case R.id.hide_notification:
                notification.Toast("Hide notification is not implemented yet");
                return true;
            default:
                return true;
        }
    }

    private void createTestingItems(){
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

    private void createParsedTestingItems(){
        // Add items into list
        ArrayList<CustomListItem> items = new ArrayList<>();
        dataParser.Sensors(items,
            "(Id = 2,Pin = 6,Name = Testovaci senzor 1,State = 0,Type = 0)," +
            "(Id = 3,Pin = 8,Name = Testovaci senzor 2,State = 1,Type = 0)," +
            "(Id = 4,Pin = 6,Name = Testovaci senzor 3,State = 0,Type = 0)"
        );

        // Set listView adapter
        ListView listView = (ListView) findViewById(R.id.listView);
        ListAdapter listAdapter = new CustomAdapter(this, items);
        listView.setAdapter(listAdapter);
    }
}