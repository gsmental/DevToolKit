#### Creation
* npx create-react-app my-app --template typescript

##### install required components/libraries
* npm i axios bootstrap dotenv jquery react-bootstrap redux react-redux react-router-dom redux-thunk router sweetalert2
* npm install --save--dev @types/jquery @types/react-redux @types/react-router-dom
* import 'bootstrap/dist/css/bootstrap.min.css';   index.tsx (root)
* import "../src/assets/css/sb-admin-2.min.css"; index.tsx (root)
* import $ from "jquery"; index.tsx (root)
* Public/index.html/head <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.2/css/all.min.css" integrity="sha512-HK5fgLBL+xu6dm/Ii3z4xhlSUyZgTT9tuc/hSrtw6uzJOvgRr2a9jyxxT1ely+B+xFAmJKVSTbpM/CuL7qxO8w==" crossorigin="anonymous" />
  

##### Additional npms
* npm i react-pdf
* npm i --save-dev @types/react-pdf
* import { Document,Page } from 'react-pdf/dist/esm/entry.webpack';
