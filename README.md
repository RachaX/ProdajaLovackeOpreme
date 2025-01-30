# ProdajaLovackeOpreme
## Uputstvo za upotrebu
### Uvod
Prodavnica lovačke opreme je aplikacija koja ima namjenu za, kako i samo ime kaže, prodaju svega vezanog za lov. Aplikacija je izrađena u programskom jeziku WC# koristeći WPF – Windows Presentation Form aplikativni okvir, odnosno framework. Kao primarni način skladištenja podataka, aplikacija koristi MySQL bazu podataka. Svrha same aplikacije jeste da na određeni način olakša lokalno vođenje i administraciju same prodavnice. Aplikacija sadrži, podržava, tri tipa korisnika, prodavca, poslovođu i dobavljača. Za samo pokretanje aplikacije je neophodno da krajnji korisnici posjeduju personalni – desktop, računar kao i uz odgovarajuće okruženje za izvršavanje aplikacije.

## Registracija i prijava na sistem
Pri pokretanju aplikacije, korisniku se otvara forma za unos vlastitih kredencijala. Forma za prijavu je ista za sve tipove korisnika. Korisnik putem interfejsa, mimo unošenja kredencijala, ima mogućnost izmjene jezika, od kojih su podržana dva tipa, srpski i engleski. Pored toga, u gornjem desnom uglu intefejsa se nalazi drop-down meni koji nudi dve opcije, odabir tamne teme ili ipak napuštanje aplikacije. Ukoliko ipak korisnik ne posjeduje nalog, ispod opcije za prijavu nalazi se dugme za registraciju koje otvara novu formu za registraciju korisnika. Kako je forma zajednička za sva tri tipa naloga, isto to važi i za formu prijave. Od korisnika se zahtijeva unos korisničkog imena, lozinke te ponovan unos iste, zahtijevano je da se poklapaju, kao i polja za unos vlastitog imena ili naziva kompanije te prezimena, tj. JIB, zavisno da li se registrujete kao dobavljač, ili ipak kao menadžer ili prodavac. Kako to izgleda možete vidjeti na slikama ispod.

![image](https://github.com/user-attachments/assets/49de79cf-55c4-4f8a-ba58-09346972cd6d)
![image](https://github.com/user-attachments/assets/cf0c2f8b-be56-49b9-a92e-88f1cdf4467a)

## Prodavac
Po uspješnoj prijavi korisnika sa nalogom prodavca, očekuje ga idući interfejs.

![image](https://github.com/user-attachments/assets/f5d4a4cd-fbd7-4708-b08c-d360b09f33e0)

Inicijalno korisniku se otvara opcija sa pregledom svih dostupnih proizvoda. Sam prodavac vidi osnovne informacije o proizvodima, njih opis kao i mjesto gdje su smještene, magacin, kao i opcija za dodavanje na račun. Kada prodavac odabere proizvode, odabirom opcije „Dodaj na račun“, kreira prvi korak ka izdavanju računa. Odabirom opcije sa korisničkom menija, s desne strane, „Izdavanje računa“ otvara mu se idući prozor.

![image](https://github.com/user-attachments/assets/27907ca3-1c37-4a93-8098-c4d0e040a207)

Prodavac ima mogućnost povećanja i izmjene količine proizvoda, te nakon dodatnih izmjena, kreira račun koji se smješta u lokalnu bazu podataka. Prozor koji predstavlja podešavanja, je prikazan na slici. Korisniku se omogućava da mimo odabira jezika na početnoj formi, sada još dodatno odabere temu u vidu palete boja, zelene i plave, odabir moda, odnosno tamnog ili svijetlog te da odabere jedan od 3 dostupna fonta, Arial, Roboto ili Helvetica. Sva podešavanja čuvaju se posebno za svakog korisnika u bazi podataka. 

![image](https://github.com/user-attachments/assets/5878eb34-e404-4ac4-8a49-1d70c377b507)

## Poslovođa
Nakon uspješne prijave korisnika sa nalogom menadžera, otvara mu se idući interfejs.

![image](https://github.com/user-attachments/assets/9ddca0eb-5182-493a-bead-98c1801481e4)

Možemo primjetiti da su početni ekrani prodavca i poslodavca veoma slični. Ono što se njima razlikuje na ovoj stranici jeste definitivno mogućnost uklanjanja proizvoda iz određenog magacina. Takođe kao što je i prodavcu omogućeno, tako i poslodavac može da filtrira proizvode, kako po magacinima tako i po kategorijama. Odabirom druge opcije iz korisničkog menija, otvara se prozor s kreiranjem izvještaja. Izgled tog prozora je prikazan na slici.

![image](https://github.com/user-attachments/assets/dae222c5-261e-49b8-b76b-a38a9d54d7fb)

Poslodavac ima mogućnost odabira za koji vremenski period kreira izvještaj, da li se to radi od dnevnom, sedmičnom ili ipak mjesečnom izvještaju. Nakon odabira opcije, kreira se zapis izvještaja i smješta u bazu podataka. 
Odabirom iduće opcije, „Ponude“, otvara se prozor svih ponuda dobavljača, gdje se u zasebnoj kartici prikazuju sledeći podaci, naziv kompanije, njezin JIB, lista proizvoda kao i mogućnost prihvatanja i odbijanja ponude. Ukoliko se poslovođa odlući na prihvatanje ponude od dobavljača, iskače mu modalni prozor gdje on vrši odabir u koji magacin šalje proizvode koji se nalaze u okviru ponude. Nakon izabranog magacina, u bazu podataka se dodaju svi proizvodi. Sve navedeno je prikazano na idućoj slici.

![image](https://github.com/user-attachments/assets/8eb13d2b-c98c-4986-a691-26f4b5ae3ffb)

Iduća opcija jeste prikaz svih zaposlenih, a pod tim mislimo prodavaca i dobavljača, odnosno jesu li aktivni. Takođe omogućeno filtriranje tipa zaposlenog.

![image](https://github.com/user-attachments/assets/1394f529-a1c2-4b97-bcb6-365c4a14fc12)

Kao što je i navedeno, još jedna funkcionalnost poslovođe jeste kreiranje, odnosno dodavanje magacina. Zahtijevana polja jestu naziv i lokacija istog.

![image](https://github.com/user-attachments/assets/9589af7c-1feb-4637-91ae-e3d32fc4d523)

Funkcionalnost podešavanja realizovana kao i za prodavca.

## Dobavljač
Ukoliko se korisnik uspješno prijavi kao dobavljač, očekuje ga idući interfejs.

![image](https://github.com/user-attachments/assets/afc5c14c-99f0-4a28-9ea4-a1615fe7a78e)

Crna tema je izabrana kao opcija. Inicijalno se dobavljaču otvara prozor gdje mu se prikazuju svi njegovi proizvodi. Proizvodi prikazani u skrolabilnom okviru. Iduća opcija jeste jedna o dve osnovne funkcionalnosti koje dobavljač posjeduje, a radi se o dodavanju proizvoda. Prikaz prozora za dodavanje je prikaz na slici ispod. 

![image](https://github.com/user-attachments/assets/01c798f7-506a-4f63-9897-6c9d96fcdb55)

Prilikom dodavanja novog proizvoda, dobavljač je dužan da unese sledeće podatke o proizvodu: naziv, cijenu, kategoriju, sliku kao i opis samog proizvoda. Proizvod kao takav, novokreirani, smješta se u bazu podataka ukazivajući na dobavljača kod kojeg je dostupan. Iduća opcija jeste ono što se očekuje od dobavljača, tj. ponuda za samu prodavnicu. Kreiranje ponude izgleda kao na slici.

![image](https://github.com/user-attachments/assets/9e24fb98-90f7-4c81-87ef-2eb298606c40)

U prikazanoj tabeli nalaze se svi proizvodi koji pripadaju dobavljaču. On ima mogućnost da izabere ili ukloni određeni proizvod iz ponude te da odredi količinu proizvoda koji šalje u okviru ponude za prodavnicu.

Opcija podešavanja realizovana kao i u ostala dva tipa naloga.

Podrazumijevana funkcionalnost sva tri tipa korisnika jeste odjavljivanje sa sistema i zaključivanje rada. Svi podaci korišteni nisu realni podaci kao ni prikazani rad sistema, nije omogućen prikaz kreiranih računa kao ni izvještaja, nego isključivo smještanje u bazu podataka.
