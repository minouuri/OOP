package org.example.entity;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.Hibernate;
import org.hibernate.cfg.Configuration;
import org.hibernate.query.Query;

import java.util.ArrayList;
import java.util.List;

@Entity
public class Buyer{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @Column(name = "name_of_buyer", unique = true)
    private String Seller;

    @Setter
    @Getter
    @Column(name = "List_of_instrument")
    @OneToMany(mappedBy = "buyer", cascade = CascadeType.ALL, orphanRemoval = true, fetch = FetchType.EAGER)
    private List<Instrument> instruments = new ArrayList<>();

    public Buyer() {}

    public Buyer(String Seller) {
        this.Seller = Seller;
    }

    public void addInstrument(Instrument instrument) {
        instrument.setBuyer(this);
        instruments.add(instrument);
    }

    public Buyer saveOrGetExisting(Buyer buyer) {
        Configuration configuration = new Configuration();
        configuration.configure();
        try (var sessionFactory = configuration.buildSessionFactory();
             var session = sessionFactory.openSession()) {

            Query<Buyer> query = session.createQuery("FROM Buyer b WHERE b.Seller = :sellerName", Buyer.class);
            query.setParameter("sellerName", buyer.Seller);
            Buyer existingBuyer = query.uniqueResult();

            if (existingBuyer != null) {
                return existingBuyer;
            } else {
                session.beginTransaction();
                session.save(buyer);
                session.getTransaction().commit();
                return buyer;
            }
        }
    }

    public static List<Instrument> getInstrumentsByBuyerId(Long buyerId) {
        Configuration configuration = new Configuration();
        configuration.configure();
        try (var sessionFactory = configuration.buildSessionFactory();
             var session = sessionFactory.openSession()) {

            Buyer buyer = session.get(Buyer.class, buyerId);
            if (buyer != null) {
                Hibernate.initialize(buyer.getInstruments());
                return buyer.getInstruments();
            }
            return new ArrayList<>();
        }
    }

}




