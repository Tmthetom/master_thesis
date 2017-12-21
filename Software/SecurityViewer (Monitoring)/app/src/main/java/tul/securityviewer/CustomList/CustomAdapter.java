package tul.securityviewer.CustomList;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CompoundButton;
import android.widget.ImageView;
import android.widget.Switch;
import android.widget.TextView;

import java.util.ArrayList;

import tul.securityviewer.Activity.ItemDetailActivity;
import tul.securityviewer.Communication.Client;
import tul.securityviewer.Communication.Operations;
import tul.securityviewer.R;

public class CustomAdapter extends ArrayAdapter<CustomListItem> {

    private Context context;
    private Client client;
    private Operations operations;

    public CustomAdapter(Context context, Client client, Operations operations, ArrayList<CustomListItem> items) {
        super(context, R.layout.custom_list_row, items);
        this.context = context;
        this.client = client;
        this.operations = operations;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        // Get layout
        ViewGroup myParent = parent;
        LayoutInflater layoutInflater = LayoutInflater.from(getContext());
        View customView = layoutInflater.inflate(R.layout.custom_list_row, parent, false);

        // Get components
        final CustomListItem customListItem = getItem(position);
        Switch mySwitch = (Switch) customView.findViewById(R.id.mySwitch);
        TextView textViewName = (TextView) customView.findViewById(R.id.textViewName);

        // Sensor
        if (customListItem.getType() == CustomListItem.Type.SENSOR){
            mySwitch.setEnabled(false);
        }

        // Same for switch and sensor
        mySwitch.setChecked(customListItem.getState());
        textViewName.setText(customListItem.getName());

        // Image view click (Open item_detail detail)
        ImageView imageView = (ImageView) customView.findViewById(R.id.imageView);
        imageView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                OpenItemDetail(customListItem);
            }
        });

        // Switch click
        mySwitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                operations.setSwitchState(client, customListItem);
            }
        });

        return customView;
    }

    // Open detail of selected item_detail
    void OpenItemDetail(CustomListItem item) {
        Intent indent = new Intent(context, ItemDetailActivity.class);

        indent.putExtra("TYPE", item.getType().toString());
        indent.putExtra("NAME", item.getName());
        indent.putExtra("PIN", item.getPin() + "");
        indent.putExtra("STATE", item.getState() ? "ON" : "OFF");
        indent.putExtra("SENSORTYPE", item.getSensorType());

        context.startActivity(indent);
    }
}