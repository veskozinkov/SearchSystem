using System.ComponentModel;

namespace SearchSystem.Others.Enums.Job;

public enum JobCategory
{
    [Description("Trade / Sales")]
    TRADE_SALES,

    [Description("Restaurants / Hotels / Tourism")]
    RESTAURANTS_HOTELS_TOURISM,

    [Description("Production")]
    PRODUCTION,

    [Description("Administrative / Office and business activities")]
    ADMINISTRATIVE_OFFICE_BUSINESS,

    [Description("Drivers / Couriers")]
    DRIVERS_COURIERS,

    [Description("Engineers / Technicians")]
    ENGINEERS_TECHNICIANS,

    [Description("Physical / Manual labor")]
    PHYSICAL_MANUAL_LABOR,

    [Description("Architecture / Construction")]
    ARCHITECTURE_CONSTRUCTION,

    [Description("Logistics / Forwarding")]
    LOGISTICS_FORWARDING,

    [Description("Healthcare / Pharmacy")]
    HEALTHCARE_PHARMACY,

    [Description("Repair / Installation")]
    REPAIR_INSTALLATION,

    [Description("Accounting / Auditing / Finance")]
    ACCOUNTING_AUDITING_FINANCE,

    [Description("Cars / Car repairs / Gas stations")]
    CARS_CAR_REPAIRS_GAS_STATIONS,

    [Description("Customer service centers")]
    CUSTOMER_SERVICE_CENTERS,

    [Description("Banks / Lending / Insurance")]
    BANKS_LENDING_INSURANCE,

    [Description("Entertainment / Promotions / Sports / Beauty salons")]
    ENTERTAINMENT_PROMOTIONS_SPORTS_BEAUTY_SALONS,

    [Description("Marketing / Advertising / PR")]
    MARKETING_ADVERTISING_PR,

    [Description("Cleaning / Gardening / Household services")]
    CLEANING_GARDENING_HOUSEHOLD_SERVICES,

    [Description("Energy / Water / Utilities")]
    ENERGY_WATER_UTILITIES,

    [Description("Safety / Security")]
    SAFETY_SECURITY,

    [Description("Telecoms")]
    TELECOMS,

    [Description("Education / Courses / Translations")]
    EDUCATION_COURSES_TRANSLATIONS,

    [Description("Management")]
    MANAGEMENT,

    [Description("Design / Creative / Art")]
    DESIGN_CREATIVE_ART,

    [Description("Human resources")]
    HR,

    [Description("Real estate")]
    REAL_ESTATE,

    [Description("State administration / Institutions")]
    STATE_ADMINISTRATION_INSTITUTIONS,

    [Description("Agriculture / Forestry / Fish / Farming")]
    AGRICULTURE_FORESTRY_FISH_FARMING,

    [Description("Research / Developement")]
    RESEARCH_DEVELOPMENT,

    [Description("Law / Legal services")]
    LAW_LEGAL_SERVICES,

    [Description("Media / Publishing")]
    MEDIA_PUBLISHING,

    [Description("Aviation / Airports / Airlines")]
    AVIATION_AIRPORTS_AIRLINES,

    [Description("Non-profit organizations")]
    NON_PROFIT_ORGANIZATIONS,

    [Description("Sea / River transport")]
    SEA_RIVER_TRANSPORT
}