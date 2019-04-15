# GubischService     
/* Aplikacja dostosowana pod jezyk niemiecki, czesc stringow jezykowych jest zdefiniowana
         na sztywno w aplikacji 
         Do zmiany jezyka trzbea przed uruchomieniem aplikacji wejsc do pliku XML 
         i zmienic z 1 na 0 ( deu na eng) w pliku Aplikacja.Gubisch.exe.config

         	   <setting name="LanguageOption" serializeAs="String">
                <value>1</value>   

            plik konfiguracyjny poza mozliwoscia zmiany jezyka daje mozliwosc ustawienia IP maszyny z ktora 
            chcemy sie polaczyc, oraz jej rack i slot. Istnieje rowniez mozliwosc ustawienia predkosci odswiezania
            danych z maszyny: 
                  <setting name="RefreshFreq" serializeAs="String">
                      <value>510</value>
                  </setting>

            Dodatkowo w pliku .config sa sciezki to plikow .png
            ktore wysietlane sa w aplikacji  ( na ta chwile sciezki prowadza do dataserver)
         
        */

        /*
         *  Aplikacja bazuje na plikach XML. Pliki XML zawieraja dane o pobranych zmiennych PLC (M,I,O,DBW).
         *  W zaleznosci od wybranego pliku XML na poczatku programu ( w zaleznosci od bita "LanguageOption")
            Plik XML bazuje na sztywnych nazwach (Chipbreaker, Tenonvisior,SawVisior itp), a kazda grupa
            zawiera blok danych typu obiekt:
            <obiekt>
              <blok_danych>M500.1</blok_danych>
              <typ_danych>Bit</typ_danych>
              <To_PLC>0</To_PLC>
              <Save>0</Save>
              <Message>0</Message>
              <komentarz>TURN DISC BACK POS</komentarz>
            </obiekt>

            obiekt zawiera nazwe <blok danych> na podstawie ktorych zassysa/wysyla dane pod ten dokladnie ten adres.
             
            WAZNE! 
                W programie jest mozliwosc odczytu bloku danych db tylko pod postacia dbx i dbw (np db2.dbw20, db2.dbx188.0)

           <typ_danych> mozna pominac, jest to furtka na przyszlosc
           <To_PLC> mozna pominac, furtka na przyszlosc
           <Save> mozna pominac, furtka na przyszlosc
           <message> - uzywane do I/O, kiedy istnieje obrazek z przypisanymi cyframi(wizualne dopasowanie)
                    wtedy dajac np <Message>1</Message> do danego I/O zostanie przypisana cyfra 1 ( dopasowanie z danego obrazka)
             <komendatrz> - w przypadku dbx'ow komentarz jest wyswietlany w formie bledu/alarmu w duzym textBoxie, w przypadku
                kieedy jest to Marker lub DBW komenatrz wyswietlany jest jako nazwa funkcji odpowiadajacej za ten bit/byte w textboxie
                w wierszu.


         */
         
            /*
             *  program podzielony jest sekwencje - czyli kazdy modul (chipbreaker,tenonvisior ... ) moze byc modyfikowany osobno
             *  wspolna czescia dla kazdego modulu jest odczyt z plc i zapis( korzystaja z tych samych funkcji), kazdy modul
             *  rowniez samodzielnie jest renderowany, oraz elementy buttonow texboxow itp nie dzidzicza ze wspolnego interfejsu
             *
             */
             
            /*
             * dodatkowo dodano 2 funkcje czasowe(timery), jeden timer odpowiada za cykl odswiezania danych z plc, czyli co 0,5s
             * odpala sie polaczenie ze sterownikiem i w zaleznosci od aktualnego panelu ladowane sa tylko te dane co potrzeba
             * Drugi timer odpowiada za wyswietlenie aktualnej godziny na pasku menu - kwestia sprawdzenia czy program w ogole zyje.
             *
             * /
             
