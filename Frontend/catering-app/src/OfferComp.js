import main_img from "./Images/main-img.png";
import "./CompStyles/OfferComp.css";

function OfferComp({ products }) {    
  console.log(products);
  
  return (
    <div className="centered">
      <div className="content-offer">
        {products.map((product) => (
          <div key={product.id} className="product-card">
            <img src={product.image} alt="Product" className="product-image" />
            <div className="product-name">{product.name}</div>
            <div className="product-price">{product.price}</div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default OfferComp;
