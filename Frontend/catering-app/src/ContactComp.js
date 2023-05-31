import main_img from "./Images/main-img.png";
import "./CompStyles/ContactComp.css";
import "./CompStyles/Content.css";

function FAQComp() {
  return (
    <div>
      <div className="content">
        <div className="container">
          <div className="imgBox">
            <img src={main_img} class="food" />
          </div>
          <div className="textBox">
            <p>Send us a message</p>
            <section>First name and Surname</section>
            <section>Email adress</section>
            <section>Message subject</section>
            <section class="">
              Lorem ipsum dolor sit amet consectetur adipisicing elit. Porro ea
              qui molestias suscipit pariatur sapiente odio necessitatibus
              veritatis perspiciatis, laboriosam amet ipsa nesciunt velit
              consectetur modi, exercitationem inventore sequi. Odio.
            </section>
            <a className="cta send" href="#">
              <button>Send</button>
            </a>
          </div>
        </div>
      </div>
    </div>
  );
}

export default FAQComp;
