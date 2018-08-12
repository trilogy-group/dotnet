# Changelog

## 0.8.0

- Added validation for hex colour codes (on ElementStyle and RelationshipStyle)
- Removed the "groups" property of documentation sections (__breaking change__).
- Added support for the HTTP-based health checks feature.
- Added an ```EndParallelSequence(boolean)``` method to the ```DynamicView``` class, which allows sequence numbering to continue.
- Added support for decision records.
- Moved PlantUML support to a separate Structurizr.PlantUML project.
- Separated the API client from the core library, and created a new Structurizr.Client project.
- Renamed the "type" property on Section to "title".

## 0.7.2

- Added some new shapes: web browser, mobile device (portrait and landscape), and robot.
- Added the ability to enable/disable the enterprise boundary on system landscape and system context views.
- Added the ability to customise the terminology used when rendering views.
- Added the ability to hide element metadata and/or descriptions.
- Bug fixes and performance enhancements.