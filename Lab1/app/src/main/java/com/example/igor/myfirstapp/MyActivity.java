package com.example.igor.myfirstapp;

import android.app.Activity;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class MyActivity extends Activity {

    EditText etImie;
    EditText etNazw;
    EditText etLiczba;
    Button btnOceny;
    /**
     * Called when the activity is first created.
     */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.my_activity);

        btnOceny = (Button) findViewById(R.id.button);
        btnOceny.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                formValidate();
            }
        });


        etImie = (EditText) findViewById(R.id.etImie);
        etNazw = (EditText) findViewById(R.id.etNazw);
        etImie.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                EditText editText = (EditText) v;
                if (!checkEmptyText(editText.getText().toString()) && !hasFocus) {
                    Toast.makeText(MyActivity.this, "Imie jest puste", Toast.LENGTH_SHORT).show();
                }
                checkViewButton();
            }
        });

        etNazw.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                EditText editText = (EditText) v;
                if (!checkEmptyText(editText.getText().toString()) && !hasFocus) {
                    Toast.makeText(MyActivity.this, "Nazwisko jest puste", Toast.LENGTH_SHORT).show();
                }
                checkViewButton();
            }
        });


        etLiczba = (EditText) findViewById(R.id.etLiczba);
        etLiczba.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                if (s.length() != 0) {
                    try{
                        int num = Integer.parseInt(s.toString());
                        if (num < 5 || num > 15) {
                            Toast.makeText(MyActivity.this, "Numer musi być od 5 do 15", Toast.LENGTH_SHORT).show();
                        }
                    }catch (NumberFormatException nfe) {
                        Toast.makeText(MyActivity.this, "Musi być numerem", Toast.LENGTH_SHORT).show();
                    };
                }
                checkViewButton();
            }

            @Override
            public void afterTextChanged(Editable s) {

            }
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (resultCode==RESULT_OK)
        {
            Bundle tobolek=data.getExtras();
            double liczba = tobolek.getDouble("srednia_ocena");
            TextView srdnLabel = (TextView) findViewById(R.id.textView2);
            srdnLabel.setVisibility(View.VISIBLE);
            TextView srdnValue = (TextView) findViewById(R.id.srednia_result);
            srdnValue.setText(""+liczba);
            srdnValue.setVisibility(View.VISIBLE);
            etImie.setFocusable(false);
            etNazw.setFocusable(false);
            etLiczba.setFocusable(false);
            String res_butt_text;
            if  (liczba > 3) {
                res_butt_text = getResources().getString(R.string.super_text);
            }else {
                res_butt_text = getResources().getString(R.string.fail_text);
            }

            btnOceny.setText(res_butt_text);
            btnOceny.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Toast.makeText(MyActivity.this, "Gratulacje! Otrzymujesz zaliczenie!", Toast.LENGTH_SHORT).show();
                    finish();
                }
            });

        }
    }

    private void checkViewButton() {
        if (!checkEmptyText(etImie.getText().toString()) || !checkEmptyText(etNazw.getText().toString()) || !checkNumerFormat(etLiczba.getText().toString())) {
            btnOceny.setVisibility(View.GONE);
        }else {
            btnOceny.setVisibility(View.VISIBLE);
        }
    }

    private void formValidate() {
        int kod_zadania = 1;
        Intent zamiar = new Intent(this, ListaOcen.class);
        int licba_ocen = Integer.parseInt(etLiczba.getText().toString());
        zamiar.putExtra("liczba_ocen",licba_ocen);
        startActivityForResult(zamiar,kod_zadania);
    }

    private boolean checkEmptyText(String str) {
        if (str.length() == 0) {
            return false;
        }
        return true;
    }

    private boolean checkNumerFormat(String s) {
        StringBuilder sb = new StringBuilder();
        if (s.length() != 0) {
            try{
                int num = Integer.parseInt(s);
                if (num < 5 || num > 15) {
                    return false;
                }
            }catch (NumberFormatException nfe) {
                if (!sb.toString().equals("")) {
                    sb.append("\n");
                }
                return false;
            };
        }else {
            return false;
        }
        return true;
    }
}
