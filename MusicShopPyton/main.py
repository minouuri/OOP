from tkinter import *
from tkinter import ttk
from tkinter import font
import tkinter.messagebox as messagebox
import psycopg2
from psycopg2 import sql
from sqlalchemy import create_engine
from sqlalchemy.orm import DeclarativeBase
from sqlalchemy import  Column, Integer, String
from sqlalchemy.orm import Session
from sqlalchemy import ForeignKey
from sqlalchemy.orm import relationship

engine = create_engine("postgresql+psycopg2://postgres:210705jim37#@localhost/MusicShopJava", echo = True)
connection = engine.connect()

class Base(DeclarativeBase):
    pass

class Buyer(Base):
    __tablename__ = "buyer"
    
    id = Column(Integer, primary_key=True)
    name_of_buyer = Column(String, unique=True)
    
    keyboards = relationship("Keyboard", back_populates="buyer")
    stringeds = relationship("Stringed", back_populates="buyer")

class Instrument:
    def __init__(self, name_of_buyer, name_of_instrument, type):
        self.name_of_buyer = name_of_buyer
        self.name_of_instrument = name_of_instrument
        self.type = type

    def Sell(self):
        message = f"Инструмент продан!"
        messagebox.showinfo("Продать", message)

    def Sound(self):
        message = f"Инструмент играет!"
        messagebox.showinfo("Играть", message)

class Keyboard(Instrument, Base):
    def __init__(self, name_of_buyer, name_of_instrument, count_of_keys, type, buyer=None):
        super().__init__(name_of_buyer, name_of_instrument, type)
        self.count_of_keys = count_of_keys
        self.buyer = buyer

    __tablename__ = "keyboard"
  
    id = Column(Integer, primary_key=True, autoincrement=True)
    name_of_buyer = Column(String)
    name_of_instrument = Column(String)
    type = Column(String)
    count_of_keys = Column(Integer)

    buyer_id = Column(Integer, ForeignKey('buyer.id'))
    buyer = relationship("Buyer", back_populates="keyboards")

    def Sell(self):
        message = f"Клавишный инструмент продан!"
        messagebox.showinfo("Продать", message)

    def Sound(self):
        message = f"Клавишный инструмент играет!"
        messagebox.showinfo("Играть", message)

    def Config(self):
        message = f"Клавишный инструмент настроен!"
        messagebox.showinfo("Настройка", message)

    def PressKeys(self):
        message = f"-нажимаем клавиши-"
        messagebox.showinfo("Нажиамть клавиши", message)

    def PressPedal(self):
        message = f"-нажимаем педаль-"
        messagebox.showinfo("Нажимать педаль", message)

    def Change(self):
        change_window = Toplevel()
        change_window["bg"] = "#addedb"
        change_window.title("Изменение данных")
        change_window.geometry("300x200")
        
        Label(change_window, text="Новое имя покупателя:", background="#addedb", font="Calibri 14").pack()
        new_buyer_entry = ttk.Entry(change_window)
        new_buyer_entry.pack()
        new_buyer_entry.insert(0, self.name_of_buyer)
        
        Label(change_window, text="Новое название инструмента:", background="#addedb", font="Calibri 14").pack()
        new_instrument_entry = ttk.Entry(change_window)
        new_instrument_entry.pack()
        new_instrument_entry.insert(0, self.name_of_instrument)
        
        Label(change_window, text="Новое количество клавиш:", background="#addedb", font="Calibri 14").pack()
        new_keys_entry = ttk.Entry(change_window)
        new_keys_entry.pack()
        new_keys_entry.insert(0, str(self.count_of_keys))
        
        def save_changes():
            with Session(autoflush=False, bind=engine) as db:
                keyboard = db.query(Keyboard).filter_by(id=self.id).first()
                if keyboard:
                    keyboard.name_of_buyer = new_buyer_entry.get()
                    keyboard.name_of_instrument = new_instrument_entry.get()
                    keyboard.count_of_keys = int(new_keys_entry.get())
                    
                    db.commit()
                    messagebox.showinfo("Успех", "Данные успешно обновлены!")
                    change_window.destroy()
                else:
                    messagebox.showerror("Ошибка", "Запись не найдена!")
        
        ttk.Button(change_window, text="Сохранить", command=save_changes).pack(pady=10)


class Stringed(Instrument, Base):
    def __init__(self, name_of_buyer, name_of_instrument, count_of_strings, type, buyer=None):
        super().__init__(name_of_buyer, name_of_instrument, type)
        self.count_of_strings = count_of_strings
        self.buyer = buyer

    __tablename__ = "stringed"
  
    id = Column(Integer, primary_key=True, autoincrement=True)
    name_of_buyer = Column(String)
    name_of_instrument = Column(String)
    count_of_strings = Column(Integer)
    type = Column(String)

    buyer_id = Column(Integer, ForeignKey('buyer.id'))
    buyer = relationship("Buyer", back_populates="stringeds")

    def Sell(self):
        message = f"Струнный инструмент продан!"
        messagebox.showinfo("Продать", message)

    def Sound(self):
        message = f"Струнный инструмент играет!"
        messagebox.showinfo("Играть", message)

    def Config(self):
        message = f"Струнный инструмент настроен!"
        messagebox.showinfo("Настройка", message)

    def StrikeStrings(self):
        message = "-бьём по срунам-"
        messagebox.showinfo("Бить по струнам", message)

    def PressChords(self):
        message = "-зажимаем-"
        messagebox.showinfo("Зажимать аккорды", message)

    def Change(self):
        change_window = Toplevel()
        change_window["bg"] = "#addedb"
        change_window.title("Изменение данных")
        change_window.geometry("300x200")
        
        Label(change_window, text="Новое имя покупателя:", background="#addedb", font="Calibri 14").pack()
        new_buyer_entry = ttk.Entry(change_window)
        new_buyer_entry.pack()
        new_buyer_entry.insert(0, self.name_of_buyer)
        
        Label(change_window, text="Новое название инструмента:", background="#addedb", font="Calibri 14").pack()
        new_instrument_entry = ttk.Entry(change_window)
        new_instrument_entry.pack()
        new_instrument_entry.insert(0, self.name_of_instrument)
        
        Label(change_window, text="Новое количество струн:", background="#addedb", font="Calibri 14").pack()
        new_strings_entry = ttk.Entry(change_window)
        new_strings_entry.pack()
        new_strings_entry.insert(0, str(self.count_of_strings))
        
        def save_changes():
            with Session(autoflush=False, bind=engine) as db:
                stringed = db.query(Stringed).filter_by(id=self.id).first()
                if stringed:
                    stringed.name_of_buyer = new_buyer_entry.get()
                    stringed.name_of_instrument = new_instrument_entry.get()
                    stringed.count_of_strings = int(new_strings_entry.get())
                    
                    db.commit()
                    messagebox.showinfo("Успех", "Данные успешно обновлены!")
                    change_window.destroy()
                else:
                    messagebox.showerror("Ошибка", "Запись не найдена!")
        
        ttk.Button(change_window, text="Сохранить", command=save_changes).pack(pady=10)
    
root = Tk()
root["bg"] = "#addedb"
root.title("Музыкальный магазин")
root.geometry("550x350")
root.resizable(False, False)

font2 = font.Font(family="Calibri", size=16, weight="normal")

def open_window_keyboard(parent, keyboard, keyboard_data):
    window_keyboard = Toplevel(parent)
    window_keyboard["bg"] = "#addedb"
    window_keyboard.title("Клавишный инструмент")
    window_keyboard.geometry("370x380")
    window_keyboard.resizable(False, False)

    date1 = ttk.Label(window_keyboard, text=f"Покупатель: ", font=font1, background="#addedb")
    date1.place(x=20, y=10)
    date12 = ttk.Label(window_keyboard, text=f"{keyboard_data['name_of_buyer']}", font=font1, background="#addedb")
    date12.place(x=140, y=10)
    date2 = ttk.Label(window_keyboard, text=f"Название: ", font=font1, background="#addedb")
    date2.place(x=20, y=40)
    date22 = ttk.Label(window_keyboard, text=f"{keyboard_data['name_of_instrument']}", font=font1, background="#addedb")
    date22.place(x=120, y=40)

    for c in range(1): window_keyboard.columnconfigure(index=c, weight=1)  
    for r in range(5): window_keyboard.rowconfigure(index=r, weight=1)

    btn_k1 = ttk.Button(window_keyboard, text="Продать инструмент", width=20, command=keyboard.Sell)
    #btn_k1.grid(row=1, column=0, ipadx=6, ipady=6)
    btn_k1.place(x=80, y=80)

    btn_k2 = ttk.Button(window_keyboard, text="Настроить инструмент", width=20, command=keyboard.Config)
    #btn_k2.grid(row=2, column=0, ipadx=6, ipady=6)
    btn_k2.place(x=80, y=130)

    btn_k3 = ttk.Button(window_keyboard, text="Сыграть на инструменте", width=20, command=keyboard.Sound)
    #btn_k3.grid(row=3, column=0, ipadx=6, ipady=6)
    btn_k3.place(x=80, y=180)

    btn_k4 = ttk.Button(window_keyboard, text="Нажимать на педаль", width=20, command=keyboard.PressPedal)
    #btn_k4.grid(row=4, column=0, ipadx=6, ipady=6)
    btn_k4.place(x=80, y=230)

    btn_k5 = ttk.Button(window_keyboard, text="Нажимать на клавиши", width=20, command=keyboard.PressKeys)
    #btn_k5.grid(row=5, column=0, ipadx=6, ipady=6)
    btn_k5.place(x=80, y=280)

    btn_k6 = ttk.Button(window_keyboard, text="Изменить", width=20, command=keyboard.Change)
    btn_k6.place(x=80, y=330)

def open_window_stringed(parent, stringed, stringed_data):
    window_stringed = Toplevel(parent)
    window_stringed["bg"] = "#addedb"
    window_stringed.title("Струнный инструмент")
    window_stringed.geometry("370x380")
    window_stringed.resizable(False, False)

    for c in range(1): window_stringed.columnconfigure(index=c, weight=1)  
    for r in range(5): window_stringed.rowconfigure(index=r, weight=1)

    date1 = ttk.Label(window_stringed, text=f"Покупатель: ", font=font1, background="#addedb")
    date1.place(x=20, y=10)
    date12 = ttk.Label(window_stringed, text=f"{stringed_data['name_of_buyer']}", font=font1, background="#addedb")
    date12.place(x=140, y=10)
    date2 = ttk.Label(window_stringed, text=f"Название: ", font=font1, background="#addedb")
    date2.place(x=20, y=40)
    date22 = ttk.Label(window_stringed, text=f"{stringed_data['name_of_instrument']}", font=font1, background="#addedb")
    date22.place(x=120, y=40)

    btn_s1 = ttk.Button(window_stringed, text="Продать инструмент", width=20, command=stringed.Sell)
    #btn_s1.grid(row=0, column=0, ipadx=6, ipady=6)
    btn_s1.place(x=80, y=80)

    btn_s2 = ttk.Button(window_stringed, text="Настроить инструмент", width=20, command=stringed.Config)
    #btn_s2.grid(row=1, column=0, ipadx=6, ipady=6)
    btn_s2.place(x=80, y=130)

    btn_s3 = ttk.Button(window_stringed, text="Сыграть на инструменте", width=20, command=stringed.Sound)
    #btn_s3.grid(row=2, column=0, ipadx=6, ipady=6)
    btn_s3.place(x=80, y=180)

    btn_s4 = ttk.Button(window_stringed, text="Зажимать аккорды", width=20, command=stringed.PressChords)
    #btn_s4.grid(row=3, column=0, ipadx=6, ipady=6)
    btn_s4.place(x=80, y=230)

    btn_s5 = ttk.Button(window_stringed, text="Бить по струнам", width=20, command=stringed.StrikeStrings)
    #btn_s5.grid(row=4, column=0, ipadx=6, ipady=6)
    btn_s5.place(x=80, y=280)

    btn_s6 = ttk.Button(window_stringed, text="Изменить", width=20, command=stringed.Change)
    btn_s6.place(x=80, y=330)

style = ttk.Style()
style.configure("TButton", font=("Calibri", 14), width=15)
font1 = font.Font(family="Calibri", size=16, weight="bold")

for c in range(2): root.columnconfigure(index=c, weight=1)
for r in range(7): root.rowconfigure(index=r, weight=1)

label_buyer = ttk.Label(text="Покупатель:", font=font1, background="#addedb")
label_buyer.grid(row=0, column=0, sticky=S)  
entry_buyer = ttk.Entry(width=28)
entry_buyer.grid(row=1, column=0, sticky=N)

label_name = ttk.Label(text="Название \nинструмента:", font=font1, background="#addedb")
label_name.grid(row=2, column=0, sticky=S)  
entry_name = ttk.Entry(width=28)
entry_name.grid(row=3, column=0,  sticky=N)

label_type = ttk.Label(text="Тип \nинструмента:", font=font1, background="#addedb")
label_type.grid(row=0, column=1, sticky=S)  
entry_type = ttk.Entry(width=28)
entry_type.grid(row=1, column=1, sticky=N)

label_count = ttk.Label(text="Количество \nструн/клавиш:", font=font1, background="#addedb")
label_count.grid(row=2, column=1, sticky=S)  
entry_count = ttk.Entry(width=28)
entry_count.grid(row=3, column=1, sticky=N)

def click_button_keys():
    with Session(autoflush=False, bind=engine) as db:
        buyer_name = entry_buyer.get()
        buyer = db.query(Buyer).filter_by(name_of_buyer=buyer_name).first()
        if not buyer:
            buyer = Buyer(name_of_buyer=buyer_name)
            db.add(buyer)
            db.commit()
        
        keyboard = Keyboard(name_of_buyer=buyer_name, name_of_instrument=entry_name.get(), count_of_keys=int(entry_count.get()),
            type=entry_type.get(), buyer=buyer)
        db.add(keyboard)
        db.commit()

        keyboard_data = {
            'name_of_buyer': keyboard.name_of_buyer, 
            'name_of_instrument': keyboard.name_of_instrument,
            'count_of_keys': keyboard.count_of_keys, 
            'type': keyboard.type,
            'id': keyboard.id
        }
        keyboard.id = keyboard.id

    open_window_keyboard(root, keyboard, keyboard_data)

def click_button_string():
    with Session(autoflush=False, bind=engine) as db:
        buyer_name = entry_buyer.get()
        buyer = db.query(Buyer).filter_by(name_of_buyer=buyer_name).first()
        if not buyer:
            buyer = Buyer(name_of_buyer=buyer_name)
            db.add(buyer)
            db.commit()
        
        stringed = Stringed(name_of_buyer=buyer_name, name_of_instrument=entry_name.get(), count_of_strings=int(entry_count.get()),
            type=entry_type.get(), buyer=buyer)
        db.add(stringed)
        db.commit()

        stringed_data = {
            'name_of_buyer': stringed.name_of_buyer, 
            'name_of_instrument': stringed.name_of_instrument,
            'count_of_strings': stringed.count_of_strings, 
            'type': stringed.type,
            'id': stringed.id
        }
        stringed.id = stringed.id

    open_window_stringed(root, stringed, stringed_data)

def print_instrument():
    print_window = Toplevel()
    print_window["bg"] = "#addedb"
    print_window.title("Инструменты покупателя")
    print_window.geometry("500x400")
    
    with Session(autoflush=False, bind=engine) as db:
        buyers = db.query(Buyer).all()
        buyer_names = [buyer.name_of_buyer for buyer in buyers]
        
        Label(print_window, text="Выберите покупателя:", background="#addedb", font = "Calibri 12").pack(pady=10)
        buyer_combobox = ttk.Combobox(print_window, values=buyer_names, state="readonly")
        buyer_combobox.pack()
        
        Label(print_window, text="Инструменты:", background="#addedb", font = "Calibri 12").pack(pady=10)
        instruments_listbox = Listbox(print_window, width=40, height=15, font = "Calibri 12")
        instruments_listbox.pack(pady=10)
        
        def show_instruments(event):
            instruments_listbox.delete(0, END)
            
            selected_buyer = buyer_combobox.get()
            if not selected_buyer:
                return
                
            buyer = db.query(Buyer).filter_by(name_of_buyer=selected_buyer).first()
            if buyer:
                for keyboard in buyer.keyboards:
                    instruments_listbox.insert(END, 
                        f"Клавишный: {keyboard.name_of_instrument} ({keyboard.count_of_keys} клавиш)")

                for stringed in buyer.stringeds:
                    instruments_listbox.insert(END, 
                        f"Струнный: {stringed.name_of_instrument} ({stringed.count_of_strings} струн)")
        
        buyer_combobox.bind("<<ComboboxSelected>>", show_instruments)
    

label_keys = ttk.Label(text="Выберите инструмент:", font=font1, background="#addedb")
label_keys.grid(row=4, column=0, columnspan=2)

btn_keys = ttk.Button(text="Клавишный", command=click_button_keys)
btn_keys.grid(row=5, column=0, ipadx=6, ipady=6, sticky=N)

btn_string = ttk.Button(text="Струнный", command=click_button_string)
btn_string.grid(row=5, column=1, ipadx=6, ipady=6, sticky=N)

btn_print = ttk.Button(text="Вывести инструменты", command=print_instrument, width=18)
btn_print.grid(row=6, column=1, ipadx=6, ipady=6, sticky=N)

root.mainloop()  
connection.close()