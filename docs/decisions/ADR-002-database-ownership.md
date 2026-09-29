Database ownership:
we are using redis geopspasial feature and offcours redis as well which is shared infrastructure for specific use case,
but business ownership remains explicit.

like

Ride service -> Ride_DB
Driver service -> Driver_DB
Payment service -> Payment_DB 

loose coupling between them and need event to trigger services