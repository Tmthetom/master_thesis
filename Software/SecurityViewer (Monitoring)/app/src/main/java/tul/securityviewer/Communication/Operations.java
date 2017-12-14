package tul.securityviewer.Communication;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.TimeUnit;

import tul.securityviewer.CustomList.CustomListItem;

public class Operations {
    DataParser dataParser = new DataParser();

    public List<CustomListItem> getAllItems(Client client){
        ArrayList<CustomListItem> items = new ArrayList<>();
        getAllSensors(client, items);
        getAllSwitches(client, items);
        return items;
    }

    private void getAllSensors(Client client, ArrayList<CustomListItem> items){
        String received = "";

        client.send("GetAllSensors");
        sleep(1);


        dataParser.sensors(items, received);
    }

    private void getAllSwitches(Client client, ArrayList<CustomListItem> items){
        String received = "";

        client.send("GetAllSwitches");
        sleep(1);


        dataParser.switches(items, received);
    }

    // Sleep for set time
    private void sleep(int seconds){
        try {
            TimeUnit.SECONDS.sleep(seconds);
        }
        catch (Exception exception){
            ;
        }
    }
}
