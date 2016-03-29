package com.example.igor.myfirstapp;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.RadioGroup;
import android.widget.TextView;

import java.util.List;

/**
 * Created by Igor on 3/29/2016.
 */
public class OcenyAdapter extends ArrayAdapter<ModelOceny> {

    private List<ModelOceny> listaOcen;
    private Activity cntxt;

    public OcenyAdapter(Activity context,  List<ModelOceny> listaOcen) {
        super(context, R.layout.list_item_ocen, listaOcen);
        this.cntxt = context;
        this.listaOcen = listaOcen;
    }

    @Override
    public int getCount() {
        return listaOcen.size();
    }

    @Override
    public ModelOceny getItem(int position) {
        return listaOcen.get(position);
    }

    @Override
    public int getPosition(ModelOceny item) {
        return super.getPosition(item);
    }

    @Override
    public long getItemId(int position) {
        return super.getItemId(position);
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        View widok = null;
        //tworzenie nowego wiersza
        if (convertView == null) {
            LayoutInflater pompka = cntxt.getLayoutInflater();
            widok = pompka.inflate(R.layout.list_item_ocen, null);
        }else{
            widok = convertView;
        }
        RadioGroup grupaOceny = (RadioGroup) widok.findViewById(R.id.radio_oceny);
        grupaOceny.setTag(listaOcen.get(position));
        grupaOceny.setOnCheckedChangeListener(
                new RadioGroup.OnCheckedChangeListener()
                {
                    @Override
                    public void onCheckedChanged(RadioGroup group, int checkedId) {

                        switch(group.getCheckedRadioButtonId()) {
                            case R.id.radio2:
                                listaOcen.get(position).setOcena(2);
                                break;
                            case R.id.radio3:
                                listaOcen.get(position).setOcena(3);
                                break;
                            case R.id.radio4:
                                listaOcen.get(position).setOcena(4);
                                break;
                            case R.id.radio5:
                                listaOcen.get(position).setOcena(5);
                                break;
                        }
                    }
                }
        );
        grupaOceny.check(R.id.radio2);
        TextView label = (TextView) widok.findViewById(R.id.ite_ocena);
        label.setText(listaOcen.get(position).getNazwa());
        if (listaOcen.get(position).getOcena() > 0) {
            switch(listaOcen.get(position).getOcena()) {
                case 2:
                    grupaOceny.check(R.id.radio2);
                    break;
                case 3:
                    grupaOceny.check(R.id.radio3);
                    break;
                case 4:
                    grupaOceny.check(R.id.radio4);
                    break;
                case 5:
                    grupaOceny.check(R.id.radio5);
                    break;
            }
        }
        return widok;
    }
}
