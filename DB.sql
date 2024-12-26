-- Users Table (Covers Admin, End User, Poojari, and Hotel/Lodge Owner)
CREATE TABLE Users (
    user_id INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(50) UNIQUE NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    full_name VARCHAR(100) NOT NULL,
    mobile_number VARCHAR(15),
    user_type NVARCHAR(50) CHECK (user_type IN ('ADMIN', 'END_USER', 'POOJARI', 'HOTEL_OWNER')) NOT NULL,
    registration_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    last_login DATETIME,
    is_active BIT DEFAULT 1,
    profile_image VARCHAR(255),
    aadhar_card VARCHAR(16)
);

-- Temple Table
CREATE TABLE Temples (
    temple_id INT PRIMARY KEY IDENTITY(1,1),
    temple_name VARCHAR(100) NOT NULL,
    location VARCHAR(200) NOT NULL,
    description TEXT,
    contact_number VARCHAR(15),
    email VARCHAR(100),
    website VARCHAR(100),
    established_year INT
);

-- Pooja Types Table
CREATE TABLE PoojaTypes (
    pooja_type_id INT PRIMARY KEY IDENTITY(1,1),
    temple_id INT,
    pooja_name VARCHAR(100) NOT NULL,
    description TEXT,
    duration_minutes INT,
    base_price DECIMAL(10, 2),
    max_participants INT,
    FOREIGN KEY (temple_id) REFERENCES Temples(temple_id)
);

-- Poojari Profile Table
CREATE TABLE PoojariProfiles (
    poojari_id INT PRIMARY KEY,
    user_id INT UNIQUE,
    temple_id INT,
    specialization VARCHAR(100),
    experience_years INT,
    languages_known VARCHAR(200),
    availability_status NVARCHAR(50) CHECK (availability_status IN ('AVAILABLE', 'BUSY', 'OFFLINE')),
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (temple_id) REFERENCES Temples(temple_id)
);

-- Pooja Booking Table
CREATE TABLE PoojaBookings (
    booking_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT,
    temple_id INT,
    pooja_type_id INT,
    poojari_id INT,
    booking_date DATE,
    booking_time TIME,
    number_of_participants INT,
    total_price DECIMAL(10, 2),
    booking_status NVARCHAR(50) CHECK (booking_status IN ('PENDING', 'CONFIRMED', 'COMPLETED', 'CANCELLED')),
    special_instructions TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (temple_id) REFERENCES Temples(temple_id),
    FOREIGN KEY (pooja_type_id) REFERENCES PoojaTypes(pooja_type_id),
    FOREIGN KEY (poojari_id) REFERENCES PoojariProfiles(poojari_id)
);

-- Accommodation/Hotel Table
CREATE TABLE Accommodations (
    accommodation_id INT PRIMARY KEY IDENTITY(1,1),
    owner_user_id INT,
    name VARCHAR(100) NOT NULL,
    location VARCHAR(200) NOT NULL,
    description TEXT,
    total_rooms INT,
    contact_number VARCHAR(15),
    email VARCHAR(100),
    website VARCHAR(100),
    proximity_to_temple FLOAT,
    FOREIGN KEY (owner_user_id) REFERENCES Users(user_id)
);

-- Room Types Table
CREATE TABLE RoomTypes (
    room_type_id INT PRIMARY KEY IDENTITY(1,1),
    accommodation_id INT,
    type_name VARCHAR(50) NOT NULL,
    capacity INT,
    base_price DECIMAL(10, 2),
    amenities TEXT,
    FOREIGN KEY (accommodation_id) REFERENCES Accommodations(accommodation_id)
);

-- Accommodation Booking Table
CREATE TABLE AccommodationBookings (
    booking_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT,
    accommodation_id INT,
    room_type_id INT,
    check_in_date DATE,
    check_out_date DATE,
    number_of_guests INT,
    total_price DECIMAL(10, 2),
    booking_status NVARCHAR(50) CHECK (booking_status IN ('PENDING', 'CONFIRMED', 'CHECKED_IN', 'CHECKED_OUT', 'CANCELLED')),
    special_requests TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (accommodation_id) REFERENCES Accommodations(accommodation_id),
    FOREIGN KEY (room_type_id) REFERENCES RoomTypes(room_type_id)
);

-- Payment Table
CREATE TABLE Payments (
    payment_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT,
    booking_id INT,
    booking_type NVARCHAR(50) CHECK (booking_type IN ('POOJA', 'ACCOMMODATION')),
    amount DECIMAL(10, 2),
    payment_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    payment_method VARCHAR(50),
    payment_status NVARCHAR(50) CHECK (payment_status IN ('PENDING', 'SUCCESS', 'FAILED')),
    transaction_id VARCHAR(100),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

-- Reviews and Ratings Table
CREATE TABLE Reviews (
    review_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT,
    booking_id INT,
    booking_type NVARCHAR(50) CHECK (booking_type IN ('POOJA', 'ACCOMMODATION')),
    rating INT CHECK (rating BETWEEN 1 AND 5),
    review_text TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);


