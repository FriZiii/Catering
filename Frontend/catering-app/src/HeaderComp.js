import logo from "./Images/logo.svg";
import "./CompStyles/HeaderComp.css";

function HeaderComp() {
  return (
    <header>
      <nav>
        <img src={logo} />

        <div className="menu" alt="Logo">
          <a href="#">Home</a>
          <a href="#">About</a>
          <a href="#">Discord</a>
          <a href="#">Contact</a>
          <button>Log in</button>
        </div>

        <button className="hamburger">
          <span className="material-icons">menu</span>
        </button>
      </nav>

      <div className="mobile-menu">
        <a href="#">Offer</a>
        <a href="#">FAQ</a>
        <a href="#">Pricing</a>
        <a href="#">Contact</a>
        <button>Sign in</button>
      </div>
    </header>
  );
}

export default HeaderComp;
