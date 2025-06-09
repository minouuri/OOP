package org.example.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.cfg.Configuration;

@Entity
public class Stringed extends Instrument {
    @Setter
    @Getter
    @Column(name = "type")
    private String type_of_instrument;

    @Setter
    @Getter
    @Column(name = "count_of_strings")
    private int count_of_strings;

    public Stringed() {}

    public Stringed(String Seller, String Name) {
        super(Seller, Name);
    }

    public Stringed(String Seller, String Name, String type_of_instrument, int count_of_strings) {
        super(Seller, Name);
        this.type_of_instrument = type_of_instrument;
        this.count_of_strings = count_of_strings;
    }

    @Override
    public void ConfigInstrument() {
        text_message = "Струнный инструмент настроен!";
    }

    @Override
    public void PlayInstrument() {
        text_message = "Струнный инструмент сыграл!";
    }

    public void ClampChord() {
        text_message = "-зажатие аккорда-";
    }

    public void StrikeSrings() {
        text_message = "-удар по струнам-";
    }

    public void save(Stringed stringed) {
        Configuration configuration = new Configuration();
        configuration.configure();
        try (var sessionFactory = configuration.buildSessionFactory();
             var session = sessionFactory.openSession();) {
            System.out.println("Успешное подключение");
            session.beginTransaction();
            session.save(stringed);
            session.getTransaction().commit();
        }
    }

    public String toString() {
        return "тип - " + type_of_instrument + ", кол-во струн - " + count_of_strings;
    }
}
