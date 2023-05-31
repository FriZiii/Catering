import logo from "./Images/logo.svg";
import "./CompStyles/FAQComp.css";
import "./CompStyles/Content.css";

function FAQComp() {
  return (
    <div>
      <h2 className="title">FAQ</h2>
      <div className="content">
        <div className="textBox">
          <div className="accordion">
            <div className="contentBx">
              <div className="label">What is a boxed meal diet?</div>
              <div className="content">
                <p>
                  A boxed meal diet, also known as a meal delivery diet or a
                  meal plan service, is a dietary approach where pre-portioned
                  and balanced meals are delivered directly to the individual's
                  doorstep. The meals are conveniently packaged in individual
                  containers or boxes, ready to be consumed without the need for
                  extensive meal preparation or cooking.
                </p>
              </div>
            </div>
            <div className="contentBx">
              <div className="label">How does meal delivery diet work?</div>
              <div className="content">
                <p>
                  You have the freedom to select and order your desired diet
                  plan. Our team diligently prepares fresh, flavorful meals,
                  carefully packaging them with care. Delivered right to your
                  doorstep on designated days, you simply need to heat up your
                  meal and indulge in its deliciousness. With minimal effort
                  required, you can enjoy the convenience and satisfaction of
                  our expertly crafted meals.
                </p>
              </div>
            </div>
            <div className="contentBx">
              <div className="label">
                What types of meals are offered in box catering?
              </div>
              <div className="content">
                <p>
                  We offer a wide variety of meals to cater to different tastes,
                  preferences, and dietary needs. You can choose your diet and a
                  number of calories you need and we will prepare tasty and
                  unique meals
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default FAQComp;
