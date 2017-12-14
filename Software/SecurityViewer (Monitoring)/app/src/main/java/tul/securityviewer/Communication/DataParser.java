package tul.securityviewer.Communication;

import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import tul.securityviewer.CustomList.CustomListItem;

/*
"(Id = 2,Pin = 6,Name = Testing sensor 1,State = 0,Type = 0)," +
"(Id = 3,Pin = 8,Name = Testing sensor 2,State = 1,Type = 0)," +
"(Id = 4,Pin = 6,Name = Testing sensor 3,State = 0,Type = 0)"
 */

public class DataParser {
    public void sensors(ArrayList<CustomListItem> items, String received) {
        // Create a Pattern object
        Pattern pattern = Pattern.compile("Id = ([0-9]+),Pin = ([0-9]+),Name = ([a-zA-Z0-9 ]+),State = ([0-1]),Type = ([0-1])");

        // Now create matcher object.
        Matcher match  = pattern.matcher(received);
        while (match.find()){
            try{
                int id = Integer.parseInt(match.group(1));
                int pin = Integer.parseInt(match.group(2));
                String name = match.group(3);
                boolean state = (Integer.parseInt(match.group(4)) == 0) ? false : true;
                boolean type = (Integer.parseInt(match.group(5)) == 0) ? false : true;

                items.add(new CustomListItem(CustomListItem.Type.SENSOR, id, pin, name, state, type));
            } catch (Exception exception){
                ;
            }
        }
    }

    public void switches(ArrayList<CustomListItem> items, String received) {
        // Create a Pattern object
        Pattern pattern = Pattern.compile("Id = ([0-9]+),Pin = ([0-9]+),Name = ([a-zA-Z0-9 ]+),State = ([0-1])");

        // Now create matcher object.
        Matcher match  = pattern.matcher(received);
        while (match.find()){
            try{
                int id = Integer.parseInt(match.group(1));
                int pin = Integer.parseInt(match.group(2));
                String name = match.group(3);
                boolean state = (Integer.parseInt(match.group(4)) == 0) ? false : true;

                items.add(new CustomListItem(CustomListItem.Type.SWITCH, id, pin, name, state));
            } catch (Exception exception){
                ;
            }
        }
    }
}
