package com.example.igor.myfirstapp;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

public class MarkActivity extends AppCompatActivity {

    TextView res;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_mark);

        res = (TextView) findViewById(R.id.res);

        Intent intent = getIntent();

        String result = intent.getStringExtra("name");
        res.setText(result);
    }
}
