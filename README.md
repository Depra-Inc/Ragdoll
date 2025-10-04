# Ragdoll

A powerful Unity package for creating and managing ragdoll physics in your games. This package provides an easy-to-use system for switching between animated and ragdoll states, with support for both humanoid and generic character rigs.

## ✨ Features

- **🎭 Dual State System**: Seamlessly switch between animated and ragdoll physics
- **🤖 Humanoid Support**: Pre-configured bone mappings for humanoid characters
- **🔧 Generic Support**: Flexible system for custom character rigs
- **⚡ Performance Optimized**: Efficient physics calculations and state management
- **🎨 Editor Tools**: Built-in sandbox for testing ragdoll configurations
- **📦 Preset System**: Save and reuse ragdoll configurations
- **🔌 Plugin Architecture**: Extensible system for custom behaviors
- **📊 Real-time Testing**: Interactive sandbox environment

## 🚀 Installation

### Via Package Manager (Recommended)

1. Open your Unity project (2022.3 or later)
2. Go to `Window` > `Package Manager`
3. Click the `+` button and select `Add package from git URL...`
4. Enter: `https://github.com/Depra-Inc/Ragdoll.git`
5. Click `Add`

### Via Git URL

Add this line to your `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.depra.ragdoll": "https://github.com/Depra-Inc/Ragdoll.git"
  }
}
```

## 📖 Quick Start

### 1. Basic Setup

```csharp
using Depra.Ragdoll;

// Add RagdollBody component to your character
var ragdollBody = character.AddComponent<RagdollBody>();

// Enable ragdoll physics
ragdollBody.Enable();

// Disable ragdoll physics (return to animation)
ragdollBody.Disable();
```

## 🎨 Editor Tools

### Ragdoll Sandbox

The package includes a built-in sandbox for testing ragdoll configurations:

1. Select a `HumanoidArmaturePreset` in your project
2. Right-click and select "Open Ragdoll Sandbox"
3. Choose a prefab to test
4. Use mouse to apply forces to the ragdoll
5. Press `R` to reset, `Esc` or `Q` to quit

### Sandbox Controls

- **Left Mouse Button**: Charge and apply force
- **R**: Reset ragdoll to initial state
- **Esc/Q**: Exit sandbox

## 🔧 Configuration

### Bone Physics Settings

Each bone can be configured with:

- **Mass**: Physics mass of the bone
- **Drag**: Air resistance
- **Angular Drag**: Rotational resistance
- **Joint Limits**: Constraint limits for connected bones
- **Collider Settings**: Shape and material properties

### Preset Management

1. Create a new `HumanoidArmaturePreset` asset
2. Configure physics parameters for each bone type
3. Assign the preset to your `HumanoidArmature`
4. Use `ApplyPreset()` to load settings
5. Use `SavePreset()` to save current configuration

## 🏗️ Architecture

The package follows a modular architecture:

```
Depra.Ragdoll/
├── Body/           # Core ragdoll components
├── Humanoid/       # Humanoid-specific implementations
├── Generic/        # Generic character support
├── Plugins/        # Extensible plugin system
├── Sandbox/        # Testing and debugging tools
└── Editor/         # Unity editor integration
```

## 🤝 Contributing

We welcome contributions! Please see our [Contributing Guidelines](CONTRIBUTING.md) for details.

## 📄 License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE.md) file for details.

## 🙏 Acknowledgments

- Unity Technologies for the amazing physics system
- The open-source community for inspiration and feedback

## 📞 Support

- **Issues**: [GitHub Issues](https://github.com/Depra-Inc/Ragdoll/issues)
- **Email**: n.melnikov@depra.org
- **Website**: [Depra Inc.](https://github.com/Depra-Inc)

---

Made with ❤️ by [Depra Inc.](https://github.com/Depra-Inc)

