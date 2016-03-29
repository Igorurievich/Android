package com.example.igor.myfirstapp;

/**
 * Created by Igor on 3/29/2016.
 */
public class ModelOceny {
    private String nazwa;
    private int ocena;

    public ModelOceny(String nazwa) {
        this.nazwa = nazwa;
    }

    public String getNazwa() {
        return nazwa;
    }

    public void setNazwa(String nazwa) {
        this.nazwa = nazwa;
    }

    public int getOcena() {
        return ocena;
    }

    public void setOcena(int ocena) {
        this.ocena = ocena;
    }
}
