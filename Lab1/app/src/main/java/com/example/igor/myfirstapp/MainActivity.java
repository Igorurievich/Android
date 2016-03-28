package com.example.igor.myfirstapp;

import android.content.DialogInterface;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {

    Button ocenyBtn;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ocenyBtn = (Button) findViewById(R.id.ocenyBtn);
        View.OnClickListener oclOcenyBtn = new View.OnClickListener() {
            @Override
            public void onClick(View view) {

            }
        };
        ocenyBtn.setOnClickListener(oclOcenyBtn);
    }
}
