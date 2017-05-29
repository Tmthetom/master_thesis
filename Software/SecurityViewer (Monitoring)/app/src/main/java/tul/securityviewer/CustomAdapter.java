package tul.securityviewer;

import android.content.Context;
import android.support.annotation.LayoutRes;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Switch;
import android.widget.TextView;

import java.util.ArrayList;

class CustomAdapter extends ArrayAdapter<CustomListItem> {
    public CustomAdapter(Context context, ArrayList<CustomListItem> items) {
        super(context, R.layout.custom_row, items);
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        // Get layout
        LayoutInflater layoutInflater = LayoutInflater.from(getContext());
        View customView = layoutInflater.inflate(R.layout.custom_row, parent, false);

        // Get components
        CustomListItem customListItem = getItem(position);
        Switch mySwitch = (Switch) customView.findViewById(R.id.mySwitch);
        TextView textViewName = (TextView) customView.findViewById(R.id.textViewName);
        //TextView textViewType = (TextView) customView.findViewById(R.id.textViewType);

        // Sensor
        if (customListItem.getType() == CustomListItem.Type.SENSOR){
            mySwitch.setEnabled(false);
            //textViewType.setText(customListItem.getSensorType());
        }

        // Switch
        else if (customListItem.getType() == CustomListItem.Type.SWITCH){
            //textViewType.setText("");
        }

        // Same for switch and sensor
        mySwitch.setChecked(customListItem.getState());
        textViewName.setText(customListItem.getName());

        return customView;
    }
}