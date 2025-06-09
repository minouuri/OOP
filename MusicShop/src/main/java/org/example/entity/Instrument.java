package org.example.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

@Setter
@Entity
@Inheritance(strategy = InheritanceType.TABLE_PER_CLASS)
public class Instrument {
    @Getter
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "id")
    private Long id;

    @Setter
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "buyer_id")
    protected Buyer buyer;

    @Getter
    @Setter
    @Column(name = "name_of_buyer")
    private String Seller;

    @Getter
    @Setter
    @Column(name = "name_of_instrument")
    private String Name;

    @Transient
    public String text_message;

    public Instrument(String Name) {
        this.Name = Name;
    }

    public Instrument(String Seller, String Name) {
        this.Seller = Seller;
        this.Name = Name;
    }

    public Instrument() {
    }

    public void Sell() {
        text_message = "Инструмент продан!";
    }

    public void ConfigInstrument() {
        text_message = "Инструмент настроен!";
    }

    public void PlayInstrument() {
        text_message = "Инструмент сыграл!";
    }

}
