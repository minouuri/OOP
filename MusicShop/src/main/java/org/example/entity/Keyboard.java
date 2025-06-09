package org.example.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.cfg.Configuration;

@Entity
public class Keyboard extends Instrument {
    @Setter
    @Getter
    @Column(name = "type")
    private String type_of_instrument;

    @Setter
    @Getter
    @Column(name = "count_of_keys")
    private int count_of_keys;

    public Keyboard() {}

    public Keyboard(String Seller, String Name) {
        super(Seller, Name);
    }

    public Keyboard(String Seller, String Name, String type_of_instrument, int count_of_keys) {
        super(Seller, Name);
        this.type_of_instrument = type_of_instrument;
        this.count_of_keys = count_of_keys;
    }

    @Override
    public void ConfigInstrument() {
        text_message = "Клавишный инструмент настроен!";
    }

    @Override
    public void PlayInstrument() {
        text_message = "Клавишный инструмент сыграл!";
    }

    public void PressPedal() {
        text_message = "-нажатие на педаль-";
    }

    public void PressKeys() {
        text_message = "-нажатие на клавишу-";
    }

    public void save(Keyboard keyboard) {
        Configuration configuration = new Configuration();
        configuration.configure();
        try (var sessionFactory = configuration.buildSessionFactory();
             var session = sessionFactory.openSession();) {
            System.out.println("Успешное подключение");
            session.beginTransaction();
            session.save(keyboard);
            session.getTransaction().commit();
        }
    }

    public String toString() {
        return "тип - " + type_of_instrument + ", кол-во клавиш - " + count_of_keys;
    }
}
