package com.example.igor.myfirstapp;

import android.content.DialogInterface;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    Button ocenyBtn;
    EditText editText3;
    EditText editText2;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ocenyBtn = (Button) findViewById(R.id.ocenyBtn);
        editText3 = (EditText) findViewById(R.id.editText3);
        editText2 = (EditText) findViewById(R.id.editText2);
        ocenyBtn.setOnClickListener(this);

    }

    @Override
    public void onClick(View v) {
        switch (v.getId())
        {
            case R.id.ocenyBtn:
            {
                Intent intent = new Intent(this, MarkActivity.class);
                intent.putExtra("name", editText3.getText().toString());
                startActivity(intent);
            }
        }
    }
}
