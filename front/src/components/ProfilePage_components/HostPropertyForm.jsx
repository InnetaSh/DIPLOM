import { useState, useContext, useRef, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { ApiContext } from "../../contexts/ApiContext.jsx";
import { useLanguage } from "../../contexts/LanguageContext.jsx";
import { ThemeContext } from "../../contexts/ThemeContext";

import styles from './HostPropertyForm.module.css';

import { Text } from "../UI/Text/Text.jsx";
import { ActionButton__Secondary } from "../UI/Button/ActionButton_Secondary.jsx";
import { ActionButton__Primary } from "../UI/Button/ActionButton_Primary.jsx";
import { IconButtonArrow } from '../UI/Button/IconButton_arrow.jsx';
import { CounterButton } from "../UI/Button/CounterButton.jsx";
import { IconButtonClose } from "../UI/Button/IconButton_close.jsx";

export const HostPropertyForm = ({
    hotel,
    setView,
    setUpdate,
    setActiveKey,
    setShowHostelList
}) => {
    const { t } = useTranslation();
    const { locationApi, offerApi, paramsCategoryApi } = useContext(ApiContext);
    const navigate = useNavigate();
    const { language } = useLanguage();
    const { darkMode } = useContext(ThemeContext);

    const fileRef = useRef(null);
    const [categoriesParams, setCategoriesParams] = useState([]);


    const classNameArrowLeft = darkMode ? "btn_arrow_left_dark" : "btn_arrow_left_light";
    const classNameArrowRight = darkMode ? "btn_arrow_right_dark" : "btn_arrow_right_light";
    const [countries, setCountries] = useState([]);
    const [imagePreviews, setImagePreviews] = useState([]);
    const [uploadedImages, setUploadedImages] = useState([]);



    const [form, setForm] = useState({
        offer: {
            id: -1,
            title: "",
            description: "",
            titleInfo: "",
            pricePerDay: "",
            pricePerWeek: "",
            pricePerMonth: "",
            tax: null,
            minRentDays: 1,
            allowPets: false,
            allowSmoking: false,
            allowChildren: false,
            allowParties: false,
            maxGuests: 1,
            checkInTime: "11:00:00",
            checkOutTime: "15:00:00",
            ownerId: null,
            rentObj: {
                id: -1,
                countryId: null,
                regionId: null,
                cityId: null,
                districtId: null,
                countryTitle: "",
                cityTitle: "",
                latitude: null,
                longitude: null,
                street: "",
                houseNumber: "",
                postcode: "",
                roomCount: 0,
                livingRoomCount: 0,
                bathroomCount: 0,
                area: 0,
                totalBedsCount: 0,
                singleBedsCount: 0,
                doubleBedsCount: 0,
                hasBabyCrib: false,
                paramValues: [],
                images: []
            }
        }
    });


    const [index, setIndex] = useState(0);

    const viewportRef = useRef(null);
    const [offset, setOffset] = useState(0);

    const getStep = () => {
        if (!viewportRef.current) return 0;

        const parentWidth = viewportRef.current.offsetWidth;
        return parentWidth * 0.32 + 10;
    };

    const handlePrev = () => {
        const step = getStep();
        setOffset(prev => Math.min(prev + step, 0));
    };

    const handleNext = () => {
        const step = getStep();

        const containerWidth = viewportRef.current.scrollWidth;
        const viewportWidth = viewportRef.current.offsetWidth;

        const maxOffset = -(containerWidth - viewportWidth);

        setOffset(prev => Math.max(prev - step, maxOffset));
    };



    useEffect(() => {
        console.log(language)
        locationApi.getFullCountries(language)
            .then(res => {
                setCountries(res.data)
                console.log({ Countries: res.data })
            })
            .catch(err => console.error("Error loading countries:", err));
    }, [language]);


    const handleCountryChange = (e) => {
        console.log("handleCountryChange triggered", e.target.value); // проверка вызова
        const selectedId = Number(e.target.value);
        const selectedCountry = countries.find(c => c.id === selectedId);
        console.log({ SelectCountries: selectedCountry })
        setForm(prev => ({
            ...prev,
            offer: {
                ...prev.offer,
                rentObj: {
                    ...prev.offer.rentObj,
                    countryId: selectedId,
                    countryTitle: selectedCountry ? selectedCountry.title : hotel ? hotel.rentObj[0].countryTitle : "",
                }
            }
        }));
    };



    const handleRegionChange = (e) => {
        const regionId = Number(e.target.value);

        setForm(prev => ({
            ...prev,
            offer: {
                ...prev.offer,
                rentObj: {
                    ...prev.offer.rentObj,
                    regionId,
                    cityId: null,
                    districtId: null
                }
            }
        }));
    };
    const handleCityChange = (e) => {
        const cityId = Number(e.target.value);
        const selectedCity = cities.find(c => c.id === cityId);

        setForm(prev => ({
            ...prev,
            offer: {
                ...prev.offer,
                rentObj: {
                    ...prev.offer.rentObj,
                    cityId,
                    cityTitle: selectedCity ? selectedCity.title : hotel ? hotel.rentObj[0].cityTitle : "",
                    districtId: null
                }
            }
        }));
    };

    // const handleDistrictChange = (e) => {
    //     const districtId = Number(e.target.value);

    //     setForm(prev => ({
    //         ...prev,
    //         rentObj: {
    //             ...prev.rentObj,
    //             districtId
    //         }
    //     }));
    // };





    const selectedCountry = countries.find(c => c.id === form.offer.rentObj.countryId);
    const regions = selectedCountry ? selectedCountry.regions : [];


    const selectedRegion = regions.find(r => r.id === form.offer.rentObj.regionId);
    const cities = selectedRegion ? selectedRegion.cities : [];

    const selectedCity = cities.find(c => c.id === form.offer.rentObj.cityId);
    const districts = selectedCity ? selectedCity.districts : [];

    useEffect(() => {
        const selectedCity = cities.find(
            c => c.id === form.offer.rentObj?.cityId
        );

        if (selectedCity) {
            console.log(selectedCity);
            setForm(prev => ({
                ...prev,
                offer: {
                    ...prev.offer,
                    rentObj: {
                        ...prev.offer.rentObj,
                        postcode: selectedCity.postCode
                    }
                }
            }));
        }
    }, [form.offer.rentObj?.cityId, cities]);

    useEffect(() => {
        console.log("Postcode updated:", form.offer.rentObj.postcode);
    }, [form.offer.rentObj.postcode]);

    useEffect(() => {
        paramsCategoryApi.getAllCategories(language)
            .then(res => setCategoriesParams(res.data))
            .catch(err => console.error("Error loading categories:", err));
    }, [language]);

    useEffect(() => {
        if (!hotel || !hotel.rentObj) return;

        console.log("title hotel: ")
        console.log({ hotel })


        const ro = hotel.rentObj[0];

        const id = ro.id;
        console.log({ id })

        setForm(prev => ({
            offer: {
                ...prev.offer,
                id: hotel.id ?? 0,
                title: hotel.title ?? "",
                description: hotel.description ?? "",
                pricePerDay: hotel.pricePerDay ?? 0,
                pricePerWeek: hotel.pricePerWeek ?? null,
                pricePerMonth: hotel.pricePerMonth ?? null,
                tax: hotel.tax ?? 0,
                allowPets: !!hotel.allowPets,
                allowSmoking: !!hotel.allowSmoking,
                allowChildren: !!hotel.allowChildren,
                allowParties: !!hotel.allowParties,
                maxGuests: hotel.maxGuests ?? 1,
                ownerId: hotel.ownerId ?? -1,
                rentObj: {
                    ...prev.offer?.rentObj,
                    id: ro.id ?? 0,
                    countryId: ro.countryId ?? 0,
                    countryTitle: ro.countryTitle ?? "",
                    regionId: ro.regionId ?? 0,
                    cityId: ro.cityId ?? 0,
                    cityTitle: ro.cityTitle ?? "",
                    districtId: ro.districtId ?? null,
                    street: ro.street ?? "",
                    houseNumber: ro.houseNumber ?? "",
                    postcode: ro.postcode ?? "",
                    latitude: ro.latitude ?? null,
                    longitude: ro.longitude ?? null,
                    roomCount: ro.roomCount ?? 0,
                    livingRoomCount: ro.livingRoomCount ?? 0,
                    bathroomCount: ro.bathroomCount ?? 0,
                    area: ro.area ?? 0,
                    totalBedsCount: ro.totalBedsCount ?? 0,
                    singleBedsCount: ro.singleBedsCount ?? 0,
                    doubleBedsCount: ro.doubleBedsCount ?? 0,
                    hasBabyCrib: !!ro.hasBabyCrib,
                    paramValues: ro.paramValues ?? [],
                    images: ro.images || []
                }
            }
        }));
    }, [hotel]);


    const handleOfferChange = (e) => {
        const { name, value, type, checked } = e.target;
        setForm(prev => ({
            ...prev,
            offer: { ...prev.offer, [name]: type === "checkbox" ? checked : value }
        }));
    };

    const handleRentObjChange = (e) => {
        const { name, value, type, checked } = e.target;
        setForm(prev => ({
            ...prev,
            offer: {
                ...prev.offer,
                rentObj: {
                    ...prev.offer.rentObj,
                    [name]: type === "checkbox" ? checked : (type === "number" ? Number(value) : value)
                }
            }
        }));
    };



    const isChecked = (paramItemId) =>
        form.offer.rentObj.paramValues?.some(
            p => p.paramItemId === paramItemId && p.valueBool === true
        ) ?? false;

    const toggleParamValue = (paramItemId) => {
        setForm(prev => {
            const paramValues = prev.offer.rentObj.paramValues || [];

            const exists = paramValues.find(p => p.paramItemId === paramItemId);
            let newValues;

            if (exists) {
                newValues = paramValues.map(p =>
                    p.paramItemId === paramItemId ? { ...p, valueBool: !p.valueBool } : p
                );
            } else {
                newValues = [
                    ...paramValues,
                    { id: -1, rentObjId: prev.offer.rentObj.id, paramItemId, valueBool: true }
                ];
            }

            return {
                ...prev,
                offer: {
                    ...prev.offer,
                    rentObj: {
                        ...prev.offer.rentObj,
                        paramValues: newValues
                    }
                }
            };
        });
    };



    // Работа с изображениями
    const handleAddImages = (e) => {
        const files = Array.from(e.target.files);

        setForm(prev => ({
            ...prev,
            offer: {
                ...prev.offer,
                rentObj: {
                    ...prev.offer.rentObj,
                    images: [
                        ...prev.offer.rentObj.images, // ← ВАЖНО
                        ...files
                    ]
                }
            }
        }));

        e.target.value = "";
    };



    const scrollToLast = () => {
        if (!viewportRef.current) return;

        viewportRef.current.scrollTo({
            left: viewportRef.current.scrollWidth,
            behavior: "smooth"
        });
    };



    const removeImage = (index) => {
        setForm(prev => ({
            ...prev,
            offer: {
                ...prev.offer,
                rentObj: {
                    ...prev.offer.rentObj,
                    images: prev.offer.rentObj.images.filter((_, i) => i !== index)
                }
            }
        }));
    };

    useEffect(() => {
        return () => {
            form.offer.rentObj.images.forEach(img => {
                if (img instanceof File) {
                    URL.revokeObjectURL(img);
                }
            });
        };
    }, [form.offer.rentObj.images]);



    useEffect(() => {
        const urls = form.offer.rentObj.images.map(img => {
            if (img instanceof File) {
                return URL.createObjectURL(img);
            }

            if (typeof img === "string") {
                return img;
            }

            if (img?.url) {
                return img.url;
            }

            return "";
        });

        setImagePreviews(urls);

        return () => {
            urls.forEach((url, index) => {
                if (form.offer.rentObj.images[index] instanceof File) {
                    URL.revokeObjectURL(url);
                }
            });
        };
    }, [form.offer.rentObj.images]);



    const buildOfferPayload = () => {
        const rentObj = form.offer.rentObj || {};
        const paramValues = Array.isArray(rentObj.paramValues) ? rentObj.paramValues : [];

        console.log("rentObj.cityTitle");
        console.log(rentObj);

        const normalizedParamValues = paramValues.map(p => ({
            paramItemId: p.paramItemId ?? 0,
            valueBool: Boolean(p.valueBool),
            valueInt: Number(p.valueInt) || 0,
            valueString: (p.valueString ?? "").toString()
        }));

        return {
            id: form.offer.id > 0 ? form.offer.id : 0,
            Title: form.offer.title ?? "",
            Description: form.offer.description ?? "",
            TitleInfo: form.offer.titleInfo ?? "",
            PricePerDay: Number(form.offer.pricePerDay) || 0,
            PricePerWeek: form.offer.pricePerWeek != null ? Number(form.offer.pricePerWeek) : null,
            PricePerMonth: form.offer.pricePerMonth != null ? Number(form.offer.pricePerMonth) : null,
            Tax: form.offer.tax != null ? Number(form.offer.tax) : null,
            MinRentDays: Number(form.offer.minRentDays) || 1,
            AllowPets: Boolean(form.offer.allowPets),
            AllowSmoking: Boolean(form.offer.allowSmoking),
            AllowChildren: Boolean(form.offer.allowChildren),
            AllowParties: Boolean(form.offer.allowParties),
            MaxGuests: Number(form.offer.maxGuests) || 1,
            CheckInTime: form.offer.checkInTime ?? "11:00:00",
            CheckOutTime: form.offer.checkOutTime ?? "15:00:00",
            OwnerId: form.offer.ownerId ?? 1,
            RentObj: {
                id: rentObj.id > 0 ? rentObj.id : 0,
                offerId: form.offer.id > 0 ? form.offer.id : 0,
                countryId: Number(rentObj.countryId) || 0,
                countryTitle: rentObj.countryTitle ?? "",
                regionId: Number(rentObj.regionId) || 0,
                cityId: Number(rentObj.cityId) || 0,
                cityTitle: rentObj.cityTitle ?? "",
                districtId: Number(rentObj.districtId) || 0,
                street: rentObj.street ?? "",
                houseNumber: rentObj.houseNumber ?? "",
                postcode: rentObj.postcode ?? "",
                latitude: Number(rentObj.latitude) || 0,
                longitude: Number(rentObj.longitude) || 0,
                roomCount: Number(rentObj.roomCount) || 0,
                livingRoomCount: Number(rentObj.livingRoomCount) || 0,
                bathroomCount: Number(rentObj.bathroomCount) || 0,
                area: Number(rentObj.area) || 0,
                totalBedsCount: Number(rentObj.totalBedsCount) || 0,
                singleBedsCount: Number(rentObj.singleBedsCount) || 0,
                doubleBedsCount: Number(rentObj.doubleBedsCount) || 0,
                hasBabyCrib: Boolean(rentObj.hasBabyCrib),
                images: rentObj.images
                    ?.filter(img => !(img instanceof File))
                    .map(img => img) || [],

                paramValues: normalizedParamValues
            }
        };
    };




    const [uploading, setUploading] = useState(false);


    const handleSave = async () => {
        try {
            document.body.style.cursor = "wait";
            setUploading(true);
            // debugger;
            const payload = buildOfferPayload();

            console.log("!!!!!!!!!!!!!");

            console.log("Попытка отправки данных на бек:", JSON.stringify(payload, null, 2));

            let offerId = form.offer.id;
            if (!offerId || offerId === -1) {
                const response = await offerApi.createOffer({ formData: buildOfferPayload(), lang: language });
                offerId = response.data;
            } else {
                await offerApi.updateOffer({ formData: buildOfferPayload(), lang: language });
            }

            const files = form.offer.rentObj.images.filter(img => img instanceof File);

            console.log("FILES:", files);



            console.log("Файлы для отправки:", files);
            console.log("offerId  отправки:", offerId);

            if (files.length > 0) {
                const imgFd = new FormData();

                files.forEach(file => {
                    imgFd.append("files", file);
                });

                console.log("FormData:");
                console.log([...imgFd.entries()]);

                await offerApi.createOfferImg({
                    formData: imgFd,
                    offerId
                });
            }

            alert("Объявление и фото успешно сохранены!");
            setView("list");
            navigate("/profile");
        } catch (error) {
            console.error(error);
            alert("Ошибка при сохранении");
        } finally {
            document.body.style.cursor = "default";
            setUploading(false);
            setUpdate(prev => prev + 1);
            setActiveKey("1");
            setShowHostelList(true)
            navigate("/profile");
        }
    };

    return (
        <section className={styles.container}>

            <div className={`${styles.title} flex-center btn-w-full`}>
                <Text text={t("Host.propertyForm.title")} type="m_600_s_36" />
            </div>

            <div className="flex-left gap-5">
                <span className={styles.required_fields}>*</span>
                <Text text={t("Booking.required_fields_note")} type="m_400_s_14" />
            </div>

            <div className={styles.block}>
                <div className={styles.block_title}>
                    <Text text={t("Host.aboutHousing.title")} type="m_600_s_32" />
                </div>

                <fieldset className={styles.fieldset}>
                    <label className={styles.label}>
                        <div className="flex-left gap-5">
                            <Text text={t("Host.aboutHousing.housing.name")} type="m_400_s_16" />
                            <span className={styles.required_fields}>*</span>
                        </div>
                    </label>
                    <input
                        className={styles.input}
                        name="title"
                        value={form.offer.title}
                        onChange={handleOfferChange}
                    />
                </fieldset>

                <fieldset className={styles.fieldset}>
                    <label className={styles.label}>
                        <div className="flex-left gap-5">
                            <Text text={t("Host.aboutHousing.housing.description")} type="m_400_s_16" />
                            <span className={styles.required_fields}>*</span>
                        </div>
                    </label>
                    <textarea
                        className={styles.textarea}
                        name="description"
                        value={form.offer.description}
                        onChange={handleOfferChange}
                    />
                </fieldset>

                <fieldset className={styles.fieldset}>
                    <label className={styles.label}>
                        <Text text={t("Host.aboutHousing.housing.address")} type="m_400_s_16" />
                        <span className={styles.required_fields}>*</span>
                    </label>


                    <select
                        className={styles.input}
                        value={form.offer.rentObj.countryId ?? ""}
                        onChange={handleCountryChange}
                    >
                        <option value="">
                            {t("Host.aboutHousing.housing.country")}
                        </option>

                        {countries.map(c => (
                            <option key={c.id} value={c.id}>
                                {c.title}
                            </option>
                        ))}
                    </select>
                </fieldset>

                <fieldset className={styles.fieldset}>
                    <select
                        className={styles.input}
                        value={form.offer.rentObj.regionId ?? ""}
                        onChange={handleRegionChange}
                        disabled={!form.offer.rentObj.countryId}
                    >
                        <option value="">{t("Host.aboutHousing.housing.region")}</option>
                        {regions.map(r => (
                            <option key={r.id} value={r.id}>{r.title}</option>
                        ))}
                    </select>

                </fieldset>


                <fieldset className={styles.fieldset}>
                    <label className={styles.label}>
                        <Text text={t("Host.aboutHousing.housing.address")} type="m_400_s_16" />
                        <span className={styles.required_fields}>*</span>
                    </label>

                    <div className={`${styles.input} flex-left ${styles.input_address}`}>
                        <select
                            className={styles.input_street}
                            value={form.offer.rentObj.cityId ?? ""}
                            onChange={handleCityChange}
                            disabled={!form.offer.rentObj.regionId}
                        >
                            <option value="">{t("Host.aboutHousing.housing.city")}</option>
                            {cities.map(c => (
                                <option key={c.id} value={c.id}>{c.title}</option>
                            ))}
                        </select>

                        <input
                            className={styles.input_house}
                            value={form.offer.rentObj.postcode || ''}
                            readOnly
                        />
                    </div>
                </fieldset>




                <fieldset className={styles.fieldset}>
                    <label className={styles.label}>
                        <div className="flex-left gap-5">
                            <Text text={t("Host.aboutHousing.housing.address")} type="m_400_s_16" />
                            <span className={styles.required_fields}>*</span>
                        </div>
                    </label>

                    <div className={`${styles.input} flex-left ${styles.input_address}`}>
                        <input
                            className={styles.input_street}
                            name="street"
                            placeholder={t("Host.aboutHousing.housing.street")}
                            value={form.offer.rentObj.street}
                            onChange={handleRentObjChange}
                        />
                        <input
                            className={styles.input_house}
                            name="houseNumber"
                            placeholder={t("Host.aboutHousing.housing.number")}
                            value={form.offer.rentObj.houseNumber}
                            onChange={handleRentObjChange}
                        />
                    </div>
                </fieldset>


            </div>

            {/* Фото */}
            <div className={styles.block}>
                <div className={styles.label}>
                    <Text text={t("Host.aboutHousing.housing.photo")} type="m_400_s_16" />
                </div>
                <div className={styles.carousel}>
                    <div className={styles.photosViewport} ref={viewportRef}>

                        <div className={styles.photos__container}
                            style={{ transform: `translateX(${offset}px)` }}
                        >
                            {form.offer.rentObj.images.length > 0 ? (
                                form.offer.rentObj.images.map((img, index) => {
                                    const key =
                                        img instanceof File
                                            ? `file-${img.name}-${index}`
                                            : `server-${img.id}`;

                                    const src =
                                        img instanceof File
                                            ? URL.createObjectURL(img)
                                            : img.url;

                                    return (
                                        <div key={key} className={styles.previewWrapper}>
                                            <img
                                                src={src}
                                                alt={`Preview ${index}`}
                                                className={styles.previewImage}
                                            />
                                            <IconButtonClose
                                                icon_name="close_red"
                                                className={styles.btn_close}
                                                onClick={() => removeImage(index)} />
                                        </div>
                                    );
                                })
                            ) : (
                                <div className={styles.emptyImages}>Нет изображений</div>
                            )}
                        </div>
                    </div>

                    <div className={styles.btn_container}>
                        <IconButtonArrow
                            onClick={handlePrev}
                            className={classNameArrowLeft}
                        />


                        <div className={` ${styles.btn__wrapper} flex-center btn-w-full`}>
                            <input
                                ref={fileRef}
                                type="file"
                                multiple
                                hidden
                                onChange={handleAddImages}
                            />
                            <ActionButton__Secondary
                                onClick={() => fileRef.current.click()}
                                className={`btn-br-r-20 ${styles.btn_add_photo}`}
                                text={t("Prrofile.HousingPanel.menu_btn_add_housing")}
                            />
                        </div>

                        <IconButtonArrow
                            onClick={handleNext}
                            className={classNameArrowRight}
                        />
                    </div>
                </div>
            </div>

            {/* Параметры / Удобства */}
            <div className={styles.block}>
                <div className={styles.block_title}>
                    <Text text={t("Host.amenities.title")} type="m_600_s_32" />
                </div>
                <div className={styles.fieldset}>
                    {categoriesParams.map(category => {
                        if (category.id === 2) return null;
                        if (category.id === 5) return null;
                        const visibleItems = category.items.filter(item => item.title && item.title.trim() !== "");
                        if (!visibleItems.length) return null;

                        return (
                            <div key={category.id} className={styles.checkbox__container}>
                                <div className={styles.block_title}>
                                    <Text type="m_600_s_24" text={category.title} />
                                </div>
                                <div className={styles.checkboxGrid}>
                                    {visibleItems.map(item => (
                                        <label key={item.id} className={styles.checkbox}>
                                            <Text type="m_400_s_16" text={item.title} />
                                            <input
                                                type="checkbox"
                                                className={styles.checkboxInput}
                                                checked={isChecked(item.id)}
                                                onChange={() => toggleParamValue(item.id)}
                                            />
                                        </label>
                                    ))}
                                </div>
                            </div>
                        );
                    })}
                </div>
            </div>

            {/* Данные об объекте */}
            <div className={`${styles.block} ${styles.block_with_border}`}>
                <div className={styles.block_with_border_title}>
                    <Text text={t("Host.dataHousing.title")} type="m_600_s_32" />
                </div>

                <div className={styles.block_with_border__row}>
                    <Text text={t("Host.dataHousing.guestCount")} type="m_700_s_20" />
                    <CounterButton value={form.offer.maxGuests} onChange={val => setForm(prev => ({ ...prev, offer: { ...prev.offer, maxGuests: val } }))} />
                </div>
                <div className={styles.block_with_border__row}>
                    <Text text={t("Host.dataHousing.roomCount")} type="m_700_s_20" />
                    <CounterButton
                        value={form.offer.rentObj.roomCount}
                        onChange={val => setForm(prev => ({
                            ...prev,
                            offer: {
                                ...prev.offer,
                                rentObj: {
                                    ...prev.offer.rentObj,
                                    roomCount: val
                                }
                            }
                        }))}
                    />

                </div>
                <div className={styles.block_with_border__row}>
                    <Text text={t("Host.dataHousing.singleBedsCount")} type="m_700_s_20" />
                    <CounterButton
                        value={form.offer.rentObj.singleBedsCount}
                        onChange={val => setForm(prev => ({
                            ...prev,
                            offer: {
                                ...prev.offer,
                                rentObj: {
                                    ...prev.offer.rentObj,
                                    singleBedsCount: val
                                }
                            }
                        }))}
                    />


                </div>
                <div className={styles.block_with_border__row}>
                    <Text text={t("Host.dataHousing.doubleBedsCount")} type="m_700_s_20" />
                    <CounterButton
                        value={form.offer.rentObj.doubleBedsCount}
                        onChange={val => setForm(prev => ({
                            ...prev,
                            offer: {
                                ...prev.offer,
                                rentObj: {
                                    ...prev.offer.rentObj,
                                    doubleBedsCount: val
                                }
                            }
                        }))}
                    />

                </div>
            </div>

            {/* Цена */}
            <div className={styles.block_price}>
                <div className={styles.block_price__row}>
                    <div className={styles.block_with_border_title}>
                        <Text text={t("Host.dataHousing.pricePerDay")} type="m_600_s_32" />
                    </div>
                    <input
                        type="number"
                        className={styles.input_price}
                        name="pricePerDay"
                        value={form.offer.pricePerDay}
                        onChange={handleOfferChange}
                    />
                </div>
                <div className={styles.block_price__row}>
                    <div className={styles.block_price_title}>
                        <Text text={t("Host.dataHousing.pricePerWeek")} type="m_600_s_32" />
                    </div>
                    <input
                        type="number"
                        className={styles.input_price}
                        name="pricePerWeek"
                        value={form.offer.pricePerWeek}
                        onChange={handleOfferChange}
                    />
                </div>


            </div>

            {/* Actions */}
            <div className={styles.actions}>
                {/* <ActionButton__Secondary
                    className="btn-br-r-20 btn-w-340 btn-h-60"
                    text={t("Host.btn_add")}
                    type="m_500"
                /> */}
                <ActionButton__Primary
                    className="btn-br-r-20 btn-w-340 btn-h-60"
                    text={t("Host.btn_save")}
                    type="m_500"
                    onClick={handleSave}
                />
            </div>
        </section>
    );
};
