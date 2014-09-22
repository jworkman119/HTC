package com.app.DetectUSB;

import android.app.Activity;
import android.os.Bundle;
import android.hardware.usb.UsbManager;
import android.hardware.usb.UsbDevice;
import android.content.Context;
import java.util.HashMap;

import android.text.AndroidCharacter;


public class MyActivity extends Activity {
    /**
     * Called when the activity is first created.
     */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        discoverUSB();
    }

    private void discoverUSB()
    {
        UsbManager manager = (UsbManager) getSystemService(Context.USB_SERVICE);


        HashMap<String, UsbDevice> deviceList = manager.getDeviceList();
        UsbDevice device = deviceList.get("deviceName");
        String Test = "Test";
    }
}
