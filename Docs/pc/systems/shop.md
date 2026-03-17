# Shop System

## Between-Floor Shop
- Display exactly 3 upgrade choices between floors.
- Player picks one option to continue run progression.
- Unselected offers are discarded for that transition.

## UpgradeData Integration
- Offers are sourced from existing `UpgradeData` assets.
- Cost, value, and next-upgrade links come directly from SO fields.
- No schema change required for base 3-choice MVP.

## Purchase Validation Flow
1. Generate 3 valid upgrade offers.
2. Validate selected offer exists and is purchasable in current state.
3. Validate player currency is sufficient.
4. Deduct currency and apply attribute change.
5. Persist via existing save/event flow.
6. Continue to floor transition.
