package tul.securityviewer;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;

public class OverviewActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.overview);

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

    // Create option settings_menu in right up corner
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu, menu);
        return true;
    }

    // Notification
    public void Notification(String message){
        Toast.makeText(this, message, Toast.LENGTH_SHORT).show();
    }
}
