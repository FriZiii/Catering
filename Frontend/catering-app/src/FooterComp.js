import logo from "./Images/logo.svg";
import facebook_icon from "./Images/Facebook.svg";
import instagram_icon from "./Images/Instagram.svg";
import './CompStyles/FooterComp.css';

function FooterComp() {
  return (
    <footer>
            <img src={logo} class="logo-footer"/>
            <div className="menu-footer">
                <a href="#">Offer</a>
                <a href="#">FAQ</a>
                <a href="#">Pricing</a>
                <a href="#">Contact</a>
            </div>
            <div className="socials">
                <img src={facebook_icon}/>
                <img src={instagram_icon}/>
            </div>
            <a>Copyrights © 2023</a>
    </footer>
  );
}

export default FooterComp;
