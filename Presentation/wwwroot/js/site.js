class Person {
    constructor(id, firstname, lastname, avatar, gender,
                PersonalNumber, City, PhoneNumber, RelatedPersonsCount) {
        this.id = id;
        this.firstname = firstname;
        this.lastname = lastname;
        this.avatar = avatar;
        this.gender = gender;
        this.PersonalNumber = PersonalNumber;
        this.City = City;
        this.PhoneNumber = PhoneNumber;
        this.RelatedPersonsCount = RelatedPersonsCount;
    }
}

const firstNames = ["John", "Jane", "Alice", "Bob", "Charlie", "Dave", "Eva", "Frank", "Grace", "Henry"];
const lastNames = ["Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Wilson"];
const cities = ["New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose"];
const genders = ["Male", "Female", "Other"];

function getRandomElement(arr) {
    return arr[Math.floor(Math.random() * arr.length)];
}

function generateRandomPhoneNumber() {
    return `(${Math.floor(Math.random() * 900) + 100}) ${Math.floor(Math.random() * 900) + 100}-${Math.floor(Math.random() * 9000) + 1000}`;
}

function generateRandomPersonalNumber() {
    return Math.floor(Math.random() * 9000000000000) + 1000000000000;
}

function generateRandomRelatedPersonsCount() {
    return Math.floor(Math.random() * 10);
}

function generateRandomAvatar() {
    return `https://i.pravatar.cc/150?img=${Math.floor(Math.random() * 70) + 1}`;
}

const persons = [];

for (let i = 1; i <= 5; i++) {
    const person = new Person(
        i,
        getRandomElement(firstNames),
        getRandomElement(lastNames),
        generateRandomAvatar(),
        getRandomElement(genders),
        generateRandomPersonalNumber(),
        getRandomElement(cities),
        generateRandomPhoneNumber(),
        generateRandomRelatedPersonsCount()
    );
    persons.push(person);
}


function populateTable(persons) {
    const tableContentArea = document.getElementById('usersTable');
    persons.forEach(person => {
        const row = document.createElement('tr');

        row.innerHTML = `
                    <td class="td-center" >${person.id}</td>
                    <td class="tb-column">
                        <div class="person-area">
                            <div class="avatar"><img src="${person.avatar}" alt="Avatar" "></div>
                            <div class="fullname">
                                <span>${person.firstname} ${person.lastname}</span>
                            </div>
                        </div>
                    </td>
                   
                    <td>${person.gender}</td>
                    <td>${person.PersonalNumber}</td>
                    <td>14/04/1997</td>
                    <td>${person.City}</td>
                    <td>${person.PhoneNumber}</td>
                    <td>${person.RelatedPersonsCount}</td> 
                    <td> 
                        <span><i class="bi bi-info-circle"></i></span>
                        <span><i class="bi bi-pencil-square"></i></span>
                        <span><i class="bi bi-trash3"></i></span>
                    </td>
                `;

        tableContentArea.appendChild(row);
    });
}

populateTable(persons);
