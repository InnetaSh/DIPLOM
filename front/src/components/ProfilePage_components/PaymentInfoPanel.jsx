import { useState, useContext, useRef, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { AuthContext } from "../../contexts/AuthContext.jsx";

import { PaymentInfoPanel_card } from "./PaymentInfoPanel_card.jsx";
import { Text } from "../UI/Text/Text.jsx"
import { StateButton__Filter } from "../UI/Button/StateButton_Filter.jsx";


import { PaymentInfoPanel_add_card } from "./PaymentInfoPanel_add_card.jsx";
import { IconButtonClose } from "../../components/UI/Button/IconButton_close.jsx";
import { GoogleButton } from '../UI/Button/GoogleButton.jsx';
import { RadioGroup } from '../UI/Button/RadioGroup.jsx';

import styles from './PaymentInfoPanel.module.css';


const cardList = [
  { id: 1, number: "...1111" }
]

const handleSearchResults = (results) => {
  console.log('Search results:', results);
};


export const PaymentInfoPanel = () => {

  const navigate = useNavigate();
  const { t } = useTranslation();
  const { register } = useContext(AuthContext);

  const contentRef = useRef(null);
  const [hasScroll, setHasScroll] = useState(false);
  const [openPaymentPanel, setOpenPaymentPanel] = useState(true);
  const [openAddCardPanel, setOpenAddCardPanel] = useState(false);

  const [formData, setFormData] = useState({
    username: "",
    password: "",
    email: "",
    phoneNumber: "",
    roleName: "Client"
  });


  useEffect(() => {
    const el = contentRef.current;
    if (!el) return;

    const checkScroll = () => {
      setHasScroll(el.scrollHeight > el.clientHeight);
    };

    checkScroll();
    window.addEventListener("resize", checkScroll);

    return () => window.removeEventListener("resize", checkScroll);
  }, []);




  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const result = await register(
        formData.username,
        formData.country,
        formData.email,
        formData.birthday,
        formData.phoneNumber
      );
      console.log("Registration success:", result);
      if (result.success) {
        navigate("/");
      } else {
        alert(result.message);
      }
    } catch (error) {
      console.error("Registration error:", error);
    }
  };

  return (
    <div className={styles.panel}>
      <div className={styles.panel__container}>
        <div className={`${styles.panel_btn} flex-between`}>
          <StateButton__Filter
            text={t("Prrofile.PaymentInfoPanel.Method_of_payment")}
            icon_name=""
            className="btn-orange btn-w-fit-content btn-h-btn-h-50 btn-br-r-20"
            onClick={() => console.log("2www")}
          />
          <Text text={t("Prrofile.PaymentInfoPanel.Transactions")} type="m_500_s_24" />
        </div>

        {openPaymentPanel && (
          <>
            {cardList && cardList.map(card => (
              <PaymentInfoPanel_card
                key={card.id}
                card={card}
              />
            ))}
            <div className={`${styles.panel__form} gap-30 mt-10`} >
              <Text text={t("Prrofile.PaymentInfoPanel.Add_card_for_payment")} type="m_500_s_16" />
              <div className={styles.card_input}>
                <Text text={t("Prrofile.PaymentInfoPanel.Your_card")} type="m_500" />
                <button
                  onClick={() => {
                    setOpenAddCardPanel(true);
                    setOpenPaymentPanel(false);
                  }}
                  className={styles.card_btn}>
                  <Text text={t("Prrofile.PaymentInfoPanel.Add_card")} type="m_500_s_16" />
                  <span className={styles.plus}>+</span>
                </button>
              </div>
            </div>
          </>
        )}
        {openAddCardPanel && (
          <div>
            <PaymentInfoPanel_add_card
              setOpenAddCardPanel={setOpenAddCardPanel}
              setOpenPaymentPanel={setOpenPaymentPanel}
            />
          </div>
        )}
      </div>
    </div>
  );
};
