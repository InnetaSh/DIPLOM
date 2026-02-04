import { useTranslation } from "react-i18next";
import styles from './HostPropertyForm.module.css';

import { Text } from "../UI/Text/Text.jsx";
import { ActionButton__Secondary } from "../UI/Button/ActionButton_Secondary.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";


export const HostPropertyForm = () => {
    const { t } = useTranslation();
    const amenitiesKeys = [
        "Host.amenities.wifi",
        "Host.amenities.bath",
        "Host.amenities.kitchen",
        "Host.amenities.ac",
        "Host.amenities.tv",
        "Host.amenities.washingMachine",
        "Host.amenities.iron",
        "Host.amenities.electricKettle",
        "Host.amenities.windowView",
        "Host.amenities.coffeeTea",
        "Host.amenities.workDesk",
        "Host.amenities.petsAllowed"
    ];


    return (
        <section className={`${styles.container} `}>
            <div className={`${styles.title} flex-center btn-w-full`}>
                <Text
                    text={t("Host.propertyForm.title")}
                    type="m_600_s_36" />
            </div>


            <div className="flex-left gap-5">
                <span className={styles.required_fields}>*</span>
                <Text text={t("Booking.required_fields_note")} type="m_400_s_14" />
            </div>

            <div className={styles.block}>
                <div className={styles.block_title}>
                    <Text
                        text={t("Host.propertyForm.owner.label")}
                        type="m_600_s_32" />
                </div>
                <label className={styles.label}>
                    <div className="flex-left gap-5">
                        <Text
                            text={t("Host.propertyForm.owner.name")}
                            type="m_400_s_16" />
                        <span className={styles.required_fields}>*</span>
                    </div>
                </label>
                <input
                    className={styles.input}
                    placeholder=""
                />
            </div>

            {/* Description */}
            <div className={styles.blockGrid}>
                <fieldset className={styles.fieldset}>
                    <div className={styles.label}>
                        <div className="flex-left gap-5">
                            <Text
                                text={t("Host.propertyForm.owner.photo")}
                                type="m_400_s_16" />
                            <span className={styles.required_fields}>*</span>
                        </div>
                    </div>
                    <div className={styles.previewCard}>
                        <img
                            src="/img/Rectangle 501.svg"
                            alt="preview"
                            className={styles.previewImage}
                        />
                    </div>

                </fieldset>
                <fieldset className={styles.fieldset}>
                    <label className={styles.label}>
                        <Text
                            text={t("Host.propertyForm.owner.description")}
                            type="m_400_s_16" />
                    </label>
                    <textarea
                        className={styles.textarea}
                        placeholder=""
                    />
                </fieldset>

            </div>

            {/* Address */}

            <div className={styles.block}>
                <div className={styles.block_title}>
                    <Text
                        text={t("Host.aboutHousing.title")}
                        type="m_600_s_32" />
                </div>
                <fieldset className={styles.fieldset}>
                    <label className={styles.label}>
                        <div className="flex-left gap-5">
                            <Text
                                text={t("Host.aboutHousing.housing.name")}
                                type="m_400_s_16" />
                            <span className={styles.required_fields}>*</span>
                        </div>
                    </label>
                    <input
                        className={styles.input}
                        placeholder="t.propertyForm.address.placeholder"
                    />
                </fieldset>
                <fieldset className={styles.fieldset}>
                    <label className={styles.label}>
                        <div className="flex-left gap-5">

                            <Text
                                text={t("Host.aboutHousing.housing.address")}
                                type="m_400_s_16" />
                            <span className={styles.required_fields}>*</span>
                        </div>
                    </label>
                    <input
                        className={styles.input}
                        placeholder="t.propertyForm.address.placeholder"
                    />
                </fieldset>
                <fieldset className={styles.fieldset}>
                    <label className={styles.label}>
                        <div className="flex-left gap-5">

                            <Text
                                text={t("Host.aboutHousing.housing.description")}
                                type="m_400_s_16" />
                            <span className={styles.required_fields}>*</span>
                        </div>
                    </label>
                    <textarea
                        className={styles.textarea}
                        placeholder=""
                    />
                </fieldset>
            </div>

            {/* Photos */}
            <div className={styles.block}>
                <div className={styles.label}>
                    <Text
                        text={t("Host.propertyForm.owner.photo")}
                        type="m_400_s_16" />
                </div>
                <div className={styles.photos}>
                    <div className={styles.photoGrid}>
                        <div />
                        <div />
                    </div>
                    <div className={styles.photoMain} />
                    <div className={styles.photoGrid}>
                        <div />
                        <div />
                    </div>
                </div>
                <div className="flex-center btn-w-full">
                    <ActionButton__Secondary
                        className={`btn-br-r-20 ${styles.btn_add_photo}`}
                        text={t("Prrofile.HousingPanel.menu_btn_add_housing")}
                        type="m_500"
                    />
                </div>
            </div>

            {/* Amenities */}
            <div className={styles.block}>
                <div className={styles.block_title}>
                    <Text
                        text={t("Host.amenities.title")}
                        type="m_600_s_32" />
                </div>
                <div className={styles.block}>
                    <div className={styles.checkboxGrid}>
                        {amenitiesKeys.map((key) => (
                            <label key={key} className={styles.checkbox}>

                                <Text
                                    type="m_400_s_16"
                                    text={t(key)}
                                />
                                <input type="checkbox" className={styles.checkboxInput} />
                            </label>
                        ))}
                    </div>
                </div>
            </div>

            {/* Price */}


            {/* Actions */}
            <div className={styles.actions}>
                <ActionButton__Secondary
                    className="btn-br-r-20 btn-w-340 btn-h-60"
                    text={t("Host.btn_add")}
                    type="m_500"
                />
                <ActionButton__Primary
                    className="btn-br-r-20 btn-w-340 btn-h-60"
                    text={t("Host.btn_save")}
                    type="m_500"
                />
            </div>
        </section>
    );
};
