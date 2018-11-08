# Changelog

## 0.9.0 (8th November 2018)

- Added the ability to specify users who should have read-write or read-only workspace access, via the ```workspace.Configuration.AddUser(username, role)``` method. 

## 0.8.3 (24th October 2018)

- Fixes a bug where client-side encrypted workspaces could not be created.

## 0.8.2 (23rd October 2018)

- Added name-value properties to relationships.
- Added the ability to define animations on the static structure diagrams.
- Removed support for colours in the corporate branding feature (__breaking change__).

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