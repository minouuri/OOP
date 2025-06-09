package org.example;

import org.example.entity.Buyer;
import org.example.entity.Instrument;
import org.example.entity.Keyboard;
import org.example.entity.Stringed;
import org.hibernate.cfg.Configuration;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    static Scanner scn = new Scanner(System.in);
    static String Seller;
    static String Name;
    static Keyboard keyboard;
    static Stringed stringed;
    static Buyer buyer;
    static List<Buyer> buyers = new ArrayList<>();

    public static void clearScreen() {
        for(int i = 0; i < 100; i++) {
            System.out.println("");
        }
    }

    public static  void CreateKeyboard() {
        System.out.println("");
        System.out.print("Имя покупателя: ");
        Seller = scn.nextLine();
        System.out.print("Название инструмента: ");
        Name = scn.nextLine();
        System.out.print("Тип инструмента: ");
        String type_of_instrument_keys = scn.nextLine();
        System.out.print("Количество клавиш: ");
        int count_of_keys = Integer.parseInt(scn.nextLine());;
        System.out.println("");

        buyer = new Buyer(Seller);
        buyer = buyer.saveOrGetExisting(buyer);
        keyboard = new Keyboard(Seller, Name, type_of_instrument_keys, count_of_keys);
        buyer.addInstrument(keyboard);

        System.out.println("Добавлен инструмент: " + Name + ",\n"
                + "покупатель - " + Seller + ",\n"
                + "тип инструмента - " + type_of_instrument_keys + ",\n"
                + "количество клавиш - " + count_of_keys + "."
        );
        keyboard.save(keyboard);
        System.out.println("");
    }

    public static void CreateStringed() {
        System.out.println("");
        System.out.print("Имя покупателя: ");
        Seller = scn.nextLine();
        System.out.print("Название магазина: ");
        Name = scn.nextLine();
        System.out.print("Тип инструмента: ");
        String type_of_instrument_strings = scn.nextLine();
        System.out.print("Количество струн: ");
        int count_of_strings = Integer.parseInt(scn.nextLine());;
        System.out.println("");

        buyer = new Buyer(Seller);
        buyer = buyer.saveOrGetExisting(buyer);
        stringed = new Stringed(Seller, Name, type_of_instrument_strings, count_of_strings);
        buyer.addInstrument(stringed);

        System.out.println("Добавлен инструмент: " + Name + ",\n"
                + "покупатель - " + Seller + ",\n"
                + "тип инструмента - " + type_of_instrument_strings + ",\n"
                + "количество струн - " + count_of_strings + "."
        );
        stringed.save(stringed);
        System.out.println("");
    }

    public static void main(String[] args) {
        boolean menu = true;

        while (menu) {
            System.out.println("1. Клавишный инстурмент");
            System.out.println("2. Струнный инстурмент");
            System.out.println("3. Вывести список инструментов покупателя");
            System.out.println("0. Выход");

            System.out.print("Выберите Инстурмент: ");
            int choice_instrument = Integer.parseInt(scn.nextLine());

            switch (choice_instrument) {

                case 1:
                    boolean keyboard_menu = true;

                    CreateKeyboard();

                    System.out.println("1. Продать инструмент");
                    System.out.println("2. Настроить инструмент");
                    System.out.println("3. Сыграть на инструменте");
                    System.out.println("4. Нажимать на педаль");
                    System.out.println("5. Нажимать на клавиши");
                    System.out.println("0. Вернуться к выбору инструмента");
                    System.out.println("");

                    while (keyboard_menu) {
                        System.out.print("Выберите действие над инструментом: ");
                        int choice_keyboard = Integer.parseInt(scn.nextLine());

                        switch (choice_keyboard) {
                            case 1:
                                keyboard.Sell();
                                System.out.println(keyboard.text_message + "\n");
                                break;
                            case 2:
                                keyboard.ConfigInstrument();
                                System.out.println(keyboard.text_message + "\n");
                                break;
                            case 3:
                                keyboard.PlayInstrument();
                                System.out.println(keyboard.text_message + "\n");
                                break;
                            case 4:
                                keyboard.PressPedal();
                                System.out.println(keyboard.text_message + "\n");
                                break;
                            case 5:
                                keyboard.PressKeys();
                                System.out.println(keyboard.text_message + "\n");
                                break;
                            case 0:
                                keyboard_menu = false;
                                break;
                        }
                    }
                    break;

                case 2:
                    boolean stringed_menu = true;

                    CreateStringed();

                    System.out.println("1. Продать инструмент");
                    System.out.println("2. Настроить инструмент");
                    System.out.println("3. Сыграть на инструменте");
                    System.out.println("4. Зажимать аккорды");
                    System.out.println("5. Бить по струнам");
                    System.out.println("0. Вернуться к выбору инструмента");
                    System.out.println("");

                    while (stringed_menu) {
                        System.out.print("Выберите действие над инструментом: ");
                        int choice_stringed = Integer.parseInt(scn.nextLine());

                        switch (choice_stringed) {
                            case 1:
                                stringed.Sell();
                                System.out.println(stringed.text_message + "\n");
                                break;
                            case 2:
                                stringed.ConfigInstrument();
                                System.out.println(stringed.text_message + "\n");
                                break;
                            case 3:
                                stringed.PlayInstrument();
                                System.out.println(stringed.text_message + "\n");
                                break;
                            case 4:
                                stringed.ClampChord();
                                System.out.println(stringed.text_message + "\n");
                                break;
                            case 5:
                                stringed.StrikeSrings();
                                System.out.println(stringed.text_message + "\n");
                                break;
                            case 0:
                                stringed_menu = false;
                                break;
                        }
                    }
                    break;

                case 3:
                    List<Instrument> instruments = new ArrayList<>();
                    System.out.print("Введите ID покупателя: ");
                    long buyerId = Long.parseLong(scn.nextLine());
                    instruments = Buyer.getInstrumentsByBuyerId(buyerId);

                    if (instruments.isEmpty()) {
                        System.out.println("Инструменты не найдены или покупатель не существует.");
                    } else {
                        System.out.println("\nНайденные инструменты:");
                        for (Instrument instrument : instruments) {
                            System.out.print("- " + instrument.getName() + ": ");
                            if (instrument instanceof Keyboard k) {
                                System.out.println(k.toString());
                            }
                            else if (instrument instanceof Stringed s) {
                                System.out.println(s.toString());
                            }
                        }
                    }

                case 0:
                    menu = false;
                    break;
            }
        }
    }
}