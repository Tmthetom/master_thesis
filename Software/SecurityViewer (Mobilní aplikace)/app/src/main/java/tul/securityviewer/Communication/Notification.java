package tul.securityviewer.Communication;

import android.content.Context;
import android.widget.Toast;

public class Notification {
    private Context context;

    public Notification(Context context) {
        this.context = context;
    }

    public void toast(String message){
        Toast.makeText(context, message, Toast.LENGTH_LONG).show();
    }

    public void exception(String className, String whenItHappened, String exceptionMessage){
        toast("Exception in [" + className + "], " +
                "when [" + whenItHappened + "]: " +
                exceptionMessage);
    }
}
