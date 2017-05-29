package tul.securityviewer;

public class CustomListItem {

    public enum Type {
        SENSOR,
        SWITCH
    }

    private Type type;
    private int id;
    private int pin;
    private String name;
    private boolean state;
    private String sensorType;  // true = push-to-make, false = push-to-break

    public CustomListItem(Type type, int id, int pin, String name, boolean state, boolean sensorType) {
        this.type = type;
        this.id = id;
        this.pin = pin;
        this.name = name;
        this.state = state;

        // Push-to-make (true)
        if (sensorType){
            this.sensorType = "Push-to-make";
        }

        // Push-to-break (false)
        else{
            this.sensorType = "Push-to-break";
        }
    }

    public Type getType() {
        return type;
    }

    public int getId() {
        return id;
    }

    public int getPin() {
        return pin;
    }

    public String getName() {
        return name;
    }

    public boolean getState() {
        return state;
    }

    public String getSensorType() {
        return sensorType;
    }
}
