package tul.securityviewer;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.FragmentActivity;
import android.widget.TextView;

public class ItemActivity extends FragmentActivity {
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.item);

        // Elements
        TextView textViewType = (TextView) findViewById(R.id.textViewType);
        TextView textViewName = (TextView) findViewById(R.id.textViewName);
        TextView textViewPin = (TextView) findViewById(R.id.textViewPin);
        TextView textViewState = (TextView) findViewById(R.id.textViewState);
        TextView textViewSensorType = (TextView) findViewById(R.id.textViewSensorType);

        // Get data from calling activity
        Intent callingActivity = getIntent();
        textViewType.setText(callingActivity.getExtras().getString("TYPE"));
        textViewName.setText(callingActivity.getExtras().getString("NAME"));
        textViewPin.setText(callingActivity.getExtras().getString("PIN"));
        textViewState.setText(callingActivity.getExtras().getString("STATE"));

        // Sensor type
        if (callingActivity.getExtras().getString("TYPE").equals(CustomListItem.Type.SENSOR.toString())){
            textViewSensorType.setText(callingActivity.getExtras().getString("SENSORTYPE"));
        }
        else{
            textViewSensorType.setText("");
            TextView textViewSensorTypeLabel = (TextView) findViewById(R.id.textViewSensorTypeLabel);
            textViewSensorTypeLabel.setText("");
        }
    }

    // Back button
    @Override
    public void onBackPressed() {
        Intent intent = new Intent();  // Returning intent
        setResult(2, intent);  // Set result code and intent
        finish();  // Close activity
    }
}
