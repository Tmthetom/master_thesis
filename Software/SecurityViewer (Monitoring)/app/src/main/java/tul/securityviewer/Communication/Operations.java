package tul.securityviewer.Communication;

import java.util.ArrayList;
import java.util.List;

import tul.securityviewer.CustomList.CustomListItem;

public class Operations {
    DataParser dataParser = new DataParser();

    public List<CustomListItem> GetAllItems(){
        ArrayList<CustomListItem> items = new ArrayList<>();
        GetAllSensors(items);
        GetAllSwitches(items);
        return items;
    }

    private List<CustomListItem> GetAllSensors(ArrayList<CustomListItem> items){
        String received = "";

        dataParser.Sensors(items, received);

        return items;
    }

    private List<CustomListItem> GetAllSwitches(ArrayList<CustomListItem> items){
        String received = "";

        dataParser.Switches(items, received);

        return items;
    }
}
