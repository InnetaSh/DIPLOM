import { useEffect, useState } from "react";
import "../../styles/globals.css"

export const HotelSectionNav = ({ sections }) => {
    const [active, setActive] = useState(null);

    useEffect(() => {
        const handleScroll = () => {
            for (const sec of sections) {
                const el = document.getElementById(sec.id);
                if (!el) continue;

                const rect = el.getBoundingClientRect();

                if (rect.top <= 120 && rect.bottom >= 120) {
                    setActive(sec.id);
                    break;
                }
            }
        };

        window.addEventListener("scroll", handleScroll);
        handleScroll();

        return () => window.removeEventListener("scroll", handleScroll);
    }, [sections]);

    const scrollTo = (id) => {
        const element = document.getElementById(id);
        if (element) {
            window.scrollTo({
                top: element.offsetTop - 80,
                behavior: "smooth",
            });
        }
    };

    return (
        <nav className="section-nav">
            {sections.map((sec) => (
                <button
                    key={sec.id}
                    className={active === sec.id ? "active" : ""}
                    onClick={() => scrollTo(sec.id)}
                >
                    {sec.label}
                </button>
            ))}
        </nav>
    );
}
