# My-Web-Project(LandMarks)

Hello, this is my web project related to Bulgarian landmarks, cities as an option, 
sample excursions as well as cultural events for the various cities (theatre productions, concerts, etc.) have been added.

<p>
  The application uses the .Net 6(Update to .Net 8) platform. Asp .Net, MVC pattern, and EF core database were used for the development. 
  The application has two areas, User and Administrator, and for both areas there are added roles. Users have rights only 
  to view and add content only to their own collections after admin approval.
  The administrator can add content such as adding sights, trips, events, cities, etc. as well as approves content 
  uploaded by users and adds it to the database.
</p>

<p>
  # Bulgarian Landmarks struct info

Short description
A web application for browsing and managing Bulgarian landmarks. Built with ASP.NET Core (MVC with Razor views), Identity for authentication, role-based authorization and support for external login via Google OAuth.

Key features
- Local user registration, login and profile management
- Role seeding: `Administrator`, `User`, `Menager` on startup
- External login with Google (OAuth)
- EF Core + SQL Server for persistent storage
- Simple responsive UI with Razor views

Technologies
- .NET 8 / .NET 9 (project-targeted TFMs in workspace)
- ASP.NET Core MVC with Razor views
- Entity Framework Core (SQL Server)
- ASP.NET Core Identity
- Google OAuth (external authentication)

Getting started (development)
Prerequisites
- .NET 8 SDK (or .NET 9 if you use that project)
- SQL Server (LocalDB or full SQL Server)
- Visual Studio 2022 (recommended) or `dotnet` CLI
</p>

<h3>The main page</h1>

<div>
  <img src="https://github.com/user-attachments/assets/756f1bf0-7aa8-478a-8766-17fcbfdffcf0" width="400" />
  <img src="https://github.com/user-attachments/assets/2089d4df-340b-4130-a046-5c2480ebac11" width="400" />
  <img src="https://github.com/user-attachments/assets/ff96341f-d310-4fd8-8b32-4d1939f47900" width="400" />
  <img src="https://github.com/user-attachments/assets/e48e727e-2572-4bb6-a469-c3c8f626457c" width="400" />
  <img src="https://github.com/user-attachments/assets/d3d7caaa-a7b9-4c53-8848-8c90abc6e540" width="400" />
  <img src="https://github.com/user-attachments/assets/bff82ee1-d591-48ae-9ec4-a6dd08aa890b" width="400" />
</div>
<hr>

<br>
<br>
<div>
    <p>
      In the navigation, right next to the name of the web application (Guide), there is a button for all options, if the user is not registered, some are missing
      options as can be seen in the attached screenshots below. Registered users have options to suggest a landmark (User suggestion is added only after admin approval) for now users 
      can add photos as a URL,
      I intend to add functionality to upload pictures in a separate database as a byte array.
   </p>
</div>

<div>
  <img src="https://github.com/user-attachments/assets/d2d7266a-4d88-471e-9bc8-01a847810262" width="500" height="300" />
  <img src="https://github.com/user-attachments/assets/2e403a17-6a96-4a08-9e71-08e2d1da6298" width="500" height="300"/>
</div>
<br>
<section>
  <p>
    Right in the middle of the navigation bar is a field to search for information on the site.  In the right part of the navigation bar are the links for 
    registration and login (You can see them on the first screenshot).
    Directly below the navigation bar, several photos of Bulgaria's nature along the Rhodope region are visualized. The following are rankings for the most visited sights, cities and trips.
  </p>
</section>
<br>
<section>
  <p>
    Next is a section with facts about Bulgaria, for the moment I have added three facts and a link to the page with "curious facts about Bulgaria". Next, 
    the footer in it has an example contact page as well as a general privacy policy (an example taken from a search of the results in Google ). On the right are links to sites from which I have drawn ideas in 
    one way or another.
  </p>
</section>
<br>
<section>
    <img src="https://github.com/user-attachments/assets/5a792f70-8657-4a55-8feb-fee5c2f540d5" width="400" />
    <br>
    <p>
       The first option that can be selected by the user is Cities, as I have currently selected only five.
      In the first photo, located on the right are the links for additional pages.
    </p>
    <img src="https://github.com/user-attachments/assets/c330c282-90bc-4dd5-8645-d7f3588107cd" width="400" />
    <img src="https://github.com/user-attachments/assets/dc8fc5e8-2594-4f2e-b3b4-8c54803ca656" width="400" />
    <img src="https://github.com/user-attachments/assets/f777ecb9-2984-4452-b5d8-b29c1470af6c" width="400" /> 
</section>
<br>
<section>
   <img src="https://github.com/user-attachments/assets/d331b8da-5c4a-4ad8-9024-2b2c6b7f218f" width="400" />
  <br>
  <p>     
     In the Sights section, twenty-five points of interest selected by me are placed.
  </p>

  https://github.com/user-attachments/assets/2b7b56cf-b35b-446e-9273-ae55624714a3

</section>

<section>
  <p>
     The next lint is events (Cultural events selected by city). In the video you can see what the page looks like. 
     For logged in users, a drop-down menu has been added with the option to add the event to the user's collection of events 
     (The second clip shows the drop-down menu with the options).
  </p>  

  https://github.com/user-attachments/assets/5c3c8854-6e4d-46f6-ada8-c57fe063c11c

  https://github.com/user-attachments/assets/6dda521e-51e0-4f82-ba26-0346c5703195
 
</section>

<section>
  <p>
      In the "Interesting facts" section, 43 facts about Bulgaria have been collected, both for history, sights and everyday life.
  </p>

  https://github.com/user-attachments/assets/a4a90827-e0e6-48cf-924f-646585d497eb
  
</section>

<section>
  <p>
    The next section is Trips (Selected trips such as the tests are taken from "Grabo").
    The contacts and the email you will see are not active.
  </p>

  https://github.com/user-attachments/assets/a33792c1-a44f-4708-8995-a865bcaa6ce8

  https://github.com/user-attachments/assets/6106a8cc-d3ac-45c2-87c7-855d9bfb6e76

</section>

<section>

  <p>
    For logged in users, there are two more options that they can access "Add Image" is the first option 
    after the user adds the address of his image a message is displayed on the screen for successful addition and that the
    image will be visible to other users after approval by an administrator will be and added to the user's collection.
    1.1 - Add functionality for uploading photos from a user cata file and processing and saving them as a byte array.
  </p>
  <p>
    Next section "Suggest a Landmark"
    In it, the user can add a name, description and location of the proposed landmark,
    he has to select a category from the dropdown menu as an option he can add a link to a photo or video of his choice.
  </p>

   <img src="https://github.com/user-attachments/assets/150570b0-a810-4ed4-9362-346133a9b510" width="400" />
 
   <img src="https://github.com/user-attachments/assets/8d4339df-e86c-4405-bacb-a50cf7053161" width="400" />

</section>
<hr>
<br>

<section>
  <p>
    In the navigation bar to the right of the drop-down menu, there is a search field, you can search for sights, photos, events, cities, as well as everything       that is found as information in the application. After entering the content you are looking for, if there is a match, you will be redirected to the results       page. if no match is found, the message "No results were found for your search" will be displayed.
  </p>

  <img src="https://github.com/user-attachments/assets/417cb2f6-7ed2-4063-8a84-003a1f9a9414" width="400" />

  https://github.com/user-attachments/assets/2929f15d-6fac-4e9c-954a-326740e4d116
</section>
<br>
<hr>
<section>

  <p>    
    After the search field, there are links for registration and login, which are located at the right end of the navigation bar.
    The login and registration form for each information input field has
    validations. there can be no empty fields, and there are a few more requirements for entering passwords.
  </p>

  <img src="https://github.com/user-attachments/assets/bab9bec1-2295-4133-b4f8-35edda427276" width="450" />
  <img src="https://github.com/user-attachments/assets/54363f61-3853-42c9-9ce4-43d16e6ea5c0" width="450" />

  <p>
    After successful registration or login, the user is redirected to the main page and two new "Logout" 
    links are visualized in the navigation bar on the far right. After clicking, the user who was logged in exits his account. 
    The other link in (the case is logged in admin) is visualized greeting to the user.
  </p>
  <p>
     It redirects to the user information section (which can be accessed from the links on the left).The options available are:
     change of email, change of username as well as first and last name. In the next section is password change.
    Two more links follow, the first is for the user's photo collection (pre-approved by the admin),the second link is a collection of events who has noted that he will visit.
  </p>

   <img src="https://github.com/user-attachments/assets/89675f42-814a-47d4-bfcc-e8c2e458799f" width="450" />
   <img src="https://github.com/user-attachments/assets/e13a73fd-9d99-477f-93b3-d02486dbfd8d" width="450" />
   <img src="https://github.com/user-attachments/assets/9d83efa8-d832-4058-b62d-3b07fd733e8e" width="450" />
   <img src="https://github.com/user-attachments/assets/354a1549-0f4b-4b46-aa9b-165ba6e6e3c6" width="450" />
   
</section>

<br>
<br>

<section>

  <p>
    Next is the admin panel, it is accessible only to a user with an administrator role and has the ability to add, 
    correct and delete all available options in the application.
    Below you will see the home page of the admin panel.
  </p>
   <img src="https://github.com/user-attachments/assets/a5523f0c-e97c-40f1-ab5b-dbdb7a9fe5e1" width="450" />

   <p>
     In the upper right navigation there are two links, the first ("Wait for Approval landmark") 
     contains information about proposed places or landmarks from registered users
   </p>
    <br>
    <br>
    <img src="https://github.com/user-attachments/assets/497415a0-3f9f-4317-99eb-d69d12ddd104" width="450" />
     <img src="https://github.com/user-attachments/assets/dcec747f-e457-4cbb-89d2-7c6b1b030506" width="450" />
    <br>
    <br>
    <p>      
      The first picture shows when no offers have been added. In the second picture you can
      see that there is already a suggestion added by a user and it is visualized in a table name, 
      description, image and after review by the admin and possibility to add.
    </p>
</section>
 <br>
 <br>

 <section>

   <img src="https://github.com/user-attachments/assets/b84d4caa-b04b-442f-bf09-f4365e3e5cb3" width="450" />
   <img src="https://github.com/user-attachments/assets/0d394fa9-aae5-4d22-a604-ba4824d95006" width="450" />

   <br>
   <br>
   <p>
     In the link "Pictures waiting for approval" pictures uploaded by the user and waiting for approval by the administrator 
     are visualized. The pictures are visualized in a div. the user. The other button 
     removes the photo from the database.
   </p>
 </section>
 <br>

 <section>
  <h3 style="text-aling= center"> New functional Index page - User pictures</h3>
  <p>
    Reordering the index page to add a new functionality to visualize the most liked photos uploaded by users.
    As you can see below in the attached video. Only registered users can like photos uploaded by 
    users. The photos are arranged in descending order.
  </p>

  
  https://github.com/user-attachments/assets/8c92f39b-8b2c-4f83-9fcc-6e6aea97b5c0

  <p>
    Directly below the photo collection is a link to the page of all photos uploaded by users. On the page you can see all photos uploaded by users,
    the name of the user who uploaded the photo on the left and
    on the right the number of users who liked the photo, only registered users can like the user's photo. You can see everything below in the attached video.
  </p>

  https://github.com/user-attachments/assets/12fc452a-3074-4c7f-9c60-8fedccdb2cf8


 </section>

