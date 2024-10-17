# Contract Monthly Claim System (CMCS)

The CMCS is a web application designed to allow lecturers to submit their claims. These claims get approved or rejected by the programme coordinator and the Academic Manger.
The system makes the submitting of claims easy as everything is done in one place. The status is updated in real time. The goal of the CMCS is to improve the effeciency,
and user experience. 

## Table of Content
1. [How it works](#howItWorks)
2. [Features](#features)
3. [Testing & Error Handling](#testing)
4. [Conclusion](#conclusion)

## How It Works

When you go onto the website you will be met with a login page. here you will enter your credentials if you have already registered or you can register. Depending on the role you will have a different view. If you are lecturer you will have a tab at the top of the website. Here you will find a dropdown where you can enter your own personla information. You will also be met with a link to submit your claims. With the claims you will not be able to submit it if you have not entered your personal details. This is because there is a drop down of the available lecturers. You will be able to see the claims and their statuses. If you are the programme coordinator you will be able to update and change the status of any claim. This change will take place in real time. 

In the Lecturer view you will see a drop down with different options.You will have the ability to calculate an estimate of your claims. you will be able to create a lecturer which will be saved to the database that will be used in other places of the Application. The Lecturer will also have the ability to upload a document linked to thier name. Lecturers will be able to submit Claims also. There will be error handling to ensure that the Lecturer enter the correct data. 

The Programme Coordinator and Academic Manager will have diffrent views but they will have the same functionality. They will have the ability to change the satus of the claim in real-time. They will also have the ability to to view and delete all the uploaded Files. 

 ## Features
 1. Claim Submission for Lecturers
    Lecturesr can submit their claims at any time with a simple click.
    There will be fields for Lecturer Name, hours worked, hourly rate additional notes and the submission of documents.

2. Approval Workflow for Coordinators and Managers
   They will have there own dedicated view to easily verify and approve the claims.
   claims will be listed with essential information allowing them to review and make a choice.

3. Document Uploads for Claims
   The types of documents that can be uploaded include PDFs, docx, and xlsx. uploaded files are securely stored and linked to the respective claim. The system supports file size limitations and allows common file    types.

4. User-Friendly Interface & Visual Design
   The user interface is designed with simplicity and usability in mind. Both the lecturers and administration have a clear and concise workflow. Everything is clear and they preform the functionality that they      were created for. for example, a button will will as a button and not a decoration. Error handling has been implemented to ensure that one knows when they have made a mistake.

5. Testing & Error Handling
   Unit Testing: Unit Testing has been done to the application to test and cover the key functionalities that need to be preformed by the application.
   Error Handling: The system has enough error handling to ensure that all the data is enterd and that it is done properly. for example for the hours worked

## Conclusion
The system ensures that Lecturers submit their claims well and that all the information required is there. There will be error handling to ensure that all the data is correct and that it will be stored correctly in the database. 
   
