package com.example.igor.myfirstapp;

import android.app.Activity;
import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;

import java.util.ArrayList;

public class ListaOcen extends Activity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.lista_ocen);

        Bundle tobolek = getIntent().getExtras();
        int liczba = tobolek.getInt("liczba_ocen");

        Log.d("habryk", "" + liczba);

        final ArrayList<ModelOceny> dane = new ArrayList<ModelOceny>();

        for(int i=1;i<=liczba;i++) {
            dane.add(new ModelOceny("Ocena "+i));
        }

        Log.d("habryk", dane.get(1).getNazwa());

        OcenyAdapter adapter=new OcenyAdapter(this,dane);
        ListView listaOcen = (ListView) findViewById(R.id.listaOcen);
        listaOcen.setAdapter(adapter);


        Button srednia_button = (Button) findViewById(R.id.srednia_ocena_button);
        srednia_button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Bundle tobolek=new Bundle();
                double srednia_ocena = 0;
                ListView lw = (ListView) findViewById(R.id.listaOcen);
                int count_ocen = lw.getAdapter().getCount();
                for(int i=0;i < lw.getAdapter().getCount();i++) {
                    ModelOceny mo = (ModelOceny) lw.getAdapter().getItem(i);
                    srednia_ocena +=mo.getOcena();
                }
                srednia_ocena = srednia_ocena/count_ocen;
                tobolek.putDouble("srednia_ocena",srednia_ocena);
                Intent zamiar=new Intent();
                zamiar.putExtras(tobolek);
                setResult(RESULT_OK,zamiar);
                finish();
            }
        });
    }

    /*@Override
    protected void onCreate() {
        super.onStart();


    }*/


}