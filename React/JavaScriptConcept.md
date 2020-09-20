## var vs let vs  const
* **var** is a global variable
* **let** is a local(scoped) variable
* **const** is read only and local variable


## Object
const person={

name : "Gurpreet",

walk(){},

talk(){}

};

person.talk();
person.name='new value';

const targetMember='name';
person[targetMember.value]='new value';


## concat vs spread operator
* const first=[1,2,3,4];
* const second=[5,6,7];
* const combine=first.concat(second);   
* const combine =[...first,...second]
* const combine =['a',...first,...second,'c']

