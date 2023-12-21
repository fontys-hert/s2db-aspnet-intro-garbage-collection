# Afval ophaalschema's!

- [Workshop unit testing](#workshop-razor-views-en-html)
- [Documentatie](#documentatie)

## Workshop Razor views en HTML

### Plaats binnen het semester

- Aan het begin van de implementatie fase (week 4 t/m 8)
- Voordat men aan de slag gaat met deze workshop is het verstandig om de workshop op de `main` branch te doen!

### Het doel van deze workshop

- Kennis maken met het schrijven van unit tests
- (Optioneel) Kennis maken met het schrijven van integratie tests
- Bekend raken met het lezen en gebruiken van andermans code

### Wat moet je doen

- Schrijf code voor de lege test methodes in de `SchemaEntryModelTests.cs` class in het `GarbageCollection.Tests` project.
- Schrijf zelf nieuwe tests in de `SchemaEntryModelTests.cs` class aan de hand van de `// TODO` comment onderaan de file.
- (Optioneel) Schrijf code voor de lege test methodes in de `SchemaEntryServiceTests.cs` class in het `GarbageCollection.Tests` project.
  - Zorg ervoor dat de testen die je schrijft niet daadwerkelijk data wegschijven naar andere files!

### De opdracht

De opdracht is om te zorgen dat de meest belangrijke logica van de applicatie getest is.

**Let op**: het zou goed kunnen dat er fouten zijn gemaakt in de code.
Overleg altijd eerst met je docent voordat je aanpassingen maakt aan de code.

---

## Documentatie

Dit document bevat een deel van het technisch ontwerp en de requirements van dit project.

Veel overwegingen en argumentatie zijn bewust achterwege gelaten.

### Architectuurkeuze

Dit project is opgezet als een twee-laagse architectuur. Er is namelijk een presentatie en een core laag. 
De presentatie laag is verantwoordelijk voor het tonen van een website aan de gebruiker. Dit kan MVC of Razor Pages zijn.
De core laag bevat alle business logica van die te maken heeft met de functionaliteit.

De communicatie tussen de lagen is direct en gekoppeld. De reden hiervoor is eenvoud en het gebrek aan vereiste kennis. 

Gezien de eenvoud en de doeleinden (project voor een workshop), zijn grote delen van het technisch en functioneel ontwerp achterwege gelaten.

In deze folder staan drie projecten:
 - `GarbageCollection.Mvc`. Dit is het asp.net MVC project.
 - `GarbageCollection.RazorPages`. Dit is het Razor Pages project
 - `GarbageCollection.Core`. Dit is het project waar entiteiten en services zich bevinden

Voor diegene die hier aan verder werken, **kies 1 van de twee presentatie lagen (MVC of Razor Pages)** en ga hiermee aan de slag.
Uiteraard moedigen we iedereen aan die beiden wil uitproberen.

#### Additionele informatie

- Programmeertaal: C#
- Framework versie: .NET 7


### User stories

Hieronder volgen de user stories genummerd op prioriteit. De lijst die volg onder iedere user story geeft weer wat de acceptatie criteria zijn.

1. Als gebruiker wil ik een overzicht van verschillende afval ophaal bedrijven, zodat ik in een oogopslag kan zien welk bedrijf voor mij van toepassing is.

- Zodra ik naar de hoofdpagina navigeer word ik direct doorgestuurd naar een overzicht van alle bedrijven met haar schema.
- Ieder bedrijf moet herkenbaar zijn aan haar naam en het deel van Nederland waar ze actief zijn.
- Ieder bedrijf moet klikbaar zijn. Als ik op het bedrijf klik moet ik naar een pagina gaan met details over dat bedrijf (zie 2).

--- 

2. Als gebruiker wil ik de details zien van een afval ophaal bedrijf, zodat ik kan zien wanneer ik mijn afval aan de straat moet zien.

- Ik moet een titel kunnen van het bedrijf.
- In een "eenvoudige weergave" moet ik kunnen zien op welke datum en wat voor een soort afval ik aan straat moet zetten.
- Het soort afval moet in het Nederlands getoond worden.
- (Optioneel) Zodra een soort afval morgen of overmorgen aan straat gezet moet worden, moet er respectievelijk "Morgen" of "Overmorgen" staan, in plaats van de datum.
- (Optioneel) Zodra een soort afval pas volgende week (over 7 dagen of later) aan straat gezet moet worden moet er "Volgende week" staan.

---

3. Als gebruiker wil ik een nieuw bedrijf aangeven in de website, zodat de administrator weet dat er een nieuw bedrijf is en hij de datums kan gaan opzoeken.

- Ik moet verplicht de bedrijfsnaam en het deel van Nederland opgeven. Zodra ik een of meer van deze velden vergeet moet ik een melding zien en opnieuw kunnen proberen.
- Zodra ik op opslaan druk en ik het alles succesvol ingevuld, moet ik teruggenavigeerd worden naar de beginpagina. Hier moet vervolgens het bedrijf in de lijst te zien zijn.



