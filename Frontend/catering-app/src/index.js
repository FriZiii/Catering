import React from 'react';
import ReactDOM from 'react-dom/client';
import './CompStyles/index.css';
import HeaderComp from './HeaderComp';
import FooterComp from './FooterComp';
import FAQComp from './FAQComp';
import ContactComp from './ContactComp';
import reportWebVitals from './reportWebVitals';
import OfferComp from './OfferComp';
import products from './products.json';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(  
  <React.StrictMode>
    <HeaderComp/>
    <OfferComp products={products}/>
    <FooterComp/>
  </React.StrictMode>
);

reportWebVitals();
