# 🗓️ CalendarApp - Application d'agenda en C# MAUI

> Application multiplateforme d'agenda personnel développée en C# MAUI, avec gestion de contacts, tâches, calendrier visuel ergonomique, et paramètres personnalisables.

## 📋 Description

CalendarApp est une application complète de gestion d'agenda, conçue pour offrir une expérience fluide et intuitive.  
Elle permet de gérer facilement ses contacts, ses événements et ses tâches, tout en offrant une synchronisation avec Google Calendar.  
L'objectif est de proposer un outil moderne et épuré, accessible aussi bien sur desktop que sur mobile.

Le projet suit une architecture claire et maintenable, avec Entity Framework Core pour la gestion des données, et un design soigné inspiré des outils professionnels modernes.

## 🧩 Fonctionnalités

- 👥 **Gestion des contacts** : Ajout, modification, suppression de contacts, stockés dans une base de données MySQL.
- ✅ **To-Do List interactive** : 
  - Ajout et suppression automatique des tâches terminées.
  - Suppression automatique des événements vides.
  - Création automatique d'une tâche par défaut pour chaque nouvel événement.
  - Affichage sous forme de carrousel de cartes ergonomique.
- 🗓️ **Calendrier visuel** :
  - Vue mensuelle avec les événements positionnés dans les bonnes cases du calendrier.
  - Navigation fluide entre les mois.
  - Design inspiré des calendriers professionnels (Notion, Google Calendar).
- ⚙️ **Page de paramètres** :
  - Connexion aux bases de données.
  - Gestion du compte Google Calendar.
- ☁️ **Synchronisation Google Calendar** :
  - Lecture des événements d’un calendrier public.
  - Intégration API Key pour la synchronisation.

## 🏗️ Architecture du projet

- **MAUI (.NET 9.0)** : Framework principal pour le développement multiplateforme.
- **Entity Framework Core + MySQL** : Gestion des données pour les contacts et la to-do list.
- **Architecture MVC** :
  - **Models/** : Modèles de données (`Evenement.cs`, `TaskItem.cs`, `Contact.cs`, etc.)
  - **Views/** : Pages XAML de l'application (`HomePage.xaml`, `CalendarPage.xaml`, etc.)
  - **Controllers/** : Logique métier et gestion des événements utilisateurs.
- **Design moderne** : Interface fluide et accessible sur tous les supports.

## 🛠️ Prérequis

- [Rider 2024.3](https://www.jetbrains.com/rider/)
- .NET 9.0 SDK
- MySQL Server (pour la gestion des données)
- Compte Google Cloud avec API Calendar activée
- macOS avec puce M3 (développement principal)

## 🚀 Lancer le projet

1. Cloner le dépôt :
   ```bash
   git clone https://github.com/8oDyy/Db_Calendar
